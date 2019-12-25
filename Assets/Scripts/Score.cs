using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : ObjectInteractionBasement
{

    private const string _HS_KEY = "hs";
    private const string _COINS_KEY = "_coins";
    public delegate void AddScore(int score);
    public static AddScore AddScoreHandler;

    public int _Score;

    private int _score;
    public int _totalScore
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if(_totalScore > _highscore)
            {
                _highscore = _totalScore;

            }
        }
    }

    public int _highscore;

    public int _Coins;
    public int _TempCoins;


    public override void Init()
    {
        if(PlayerPrefs.HasKey("hs"))
        _highscore = PlayerPrefs.GetInt(_HS_KEY, 0);
        _Coins = PlayerPrefs.GetInt(_COINS_KEY, 0);
    }

    public void ResetScore()
    {
        _Score = 0;
        AddScoreHandler(_Score);
    }

    public void ResetTotalScore()
    {
        _totalScore = 0;
        _TempCoins = 0;
    }

    public override void Interact()
    {
        base.Interact();
        PlayerPrefs.SetInt(_HS_KEY, _highscore);
        Debug.Log(_Coins);
        PlayerPrefs.SetInt(_COINS_KEY, _Coins);
    }

    public void AddLevelPoints()
    {
        _totalScore++;
    }

    public void Add()
    {
        _Score++;
        AddLevelPoints();
        if(AddScoreHandler != null)
        AddScoreHandler(_Score);

        _Logic.CheckScore(_Score);
    }

    public void AddCoins(int count)
    {
        _Coins += count;
        PlayerPrefs.SetInt(_COINS_KEY, _Coins);
    }

    public void AddTempCoins(int count)
    {
        _TempCoins += count;
    }

    public void ApplyTempCoins()
    {
        AddCoins(_TempCoins);
        _TempCoins = 0;
    }
}
