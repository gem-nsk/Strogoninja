using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDifficulty;

[CreateAssetMenu(fileName = "New Level Pattern", menuName = "New Pattern/Level Pattern")]
public class LevelPattern : ScriptableObject
{
    public LevelSettings._Difficulty[] _Difficulty;


    public IGameDifficulty GetDifficulty(int level)
    {
        int i = level % 10;
        switch (_Difficulty[i])
        {
            case LevelSettings._Difficulty.Easy:
                return new GameDifficulty_Easy();
            case LevelSettings._Difficulty.Medium:
                return new GameDifficulty_Medium();
            case LevelSettings._Difficulty.Hard:
                return new GameDifficulty_Hard();

            default:
                return new GameDifficulty_Medium();
        }
    }
}
