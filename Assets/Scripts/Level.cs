using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelSettings
{
    public int _levelNumber; 
    public float _SpeedModifier;
    public int _TargetPoints;
    public float _StartPenalty;
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
        _Settings = GetLevelFromResources(id);
        PlayerPrefs.SetInt(LevelIdKey, id);

        //analytics
        Firebase.Analytics.Parameter[] _Params =
        {
            new Firebase.Analytics.Parameter(Firebase.Analytics.FirebaseAnalytics.ParameterLevel, _Settings._levelNumber)
        };

        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp, _Params);
        Debug.Log("event sended - level" + _Settings._levelNumber);
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

    public LevelSettings GetLevelFromResources(int id)
    {
        LevelObject _settings = (LevelObject)Resources.Load("Levels/level_" + id);
        if (_settings)
        {
            return _settings._Setup;
        }
        else
        {
            return _Pattern.GetDifficulty(id).GetSettings(id);
        }
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
                _TargetPoints = 60,
                _StartPenalty = 0.7f
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
                _SpeedModifier = 1.2f,
                _TargetPoints = 100,
                _StartPenalty = 1.2f
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
                _SpeedModifier = 1f,
                _TargetPoints = 120,
                _StartPenalty = 1.5f
            };
        }
    }
}
