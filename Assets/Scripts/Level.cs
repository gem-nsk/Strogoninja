using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelSettings
{
    public int _levelNumber; 
    public float _SpeedModifier;
    public int _TargetPoints;
    public enum _Difficulty
    {
        Easy,
        Medium,
        Hard
    }

}

public class Level : ObjectInteractionBasement
{
    public LevelSettings _Settings;
    public LevelPattern _Pattern;

    private const string LevelIdKey = "_level";

    public override void Init()
    {
        base.Init();

        if (SaveExists())
        {
            //load current
            int LastLevelId = PlayerPrefs.GetInt(LevelIdKey);
            Setlevel(LastLevelId);
        }
        else
        {
            //first start
            PlayerPrefs.SetInt(LevelIdKey, 1);
            Setlevel(1);
        }
    }

    public void Setlevel(int id)
    {
        _Settings = _Pattern.GetDifficulty(id).GetSettings(id);
    }
    private bool SaveExists()
    {
        if (PlayerPrefs.HasKey(LevelIdKey))
        {
            return true;
        }
        else
            return false;
    }
}



namespace GameDifficulty
{

    public interface IGameDifficulty
    {
        LevelSettings GetSettings(int level);
    }

    public class GameDifficulty_Easy : IGameDifficulty
    {
        public LevelSettings GetSettings(int level)
        {
            return new LevelSettings()
            {
                _levelNumber = level,
                _SpeedModifier = 1.3f,
                _TargetPoints = 60
            };
        }
    }
    public class GameDifficulty_Medium : IGameDifficulty
    {
        public LevelSettings GetSettings(int level)
        {
            return new LevelSettings()
            {
                _levelNumber = level,
                _SpeedModifier = 1f,
                _TargetPoints = 100
            };
        }
    }
    public class GameDifficulty_Hard : IGameDifficulty
    {
        public LevelSettings GetSettings(int level)
        {
            return new LevelSettings()
            {
                _levelNumber = level,
                _SpeedModifier = 0.7f,
                _TargetPoints = 120
            };
        }
    }
}
