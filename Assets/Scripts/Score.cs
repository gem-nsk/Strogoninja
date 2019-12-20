using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : ObjectInteractionBasement
{
   

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


    public override void Init()
    {
        if(PlayerPrefs.HasKey("hs"))
        _highscore = PlayerPrefs.GetInt("hs");
    }



    public void ResetScore()
    {
        _Score = 0;
        AddScoreHandler(_Score);
    }

    public void ResetTotalScore()
    {
        _totalScore = 0;
    }

    public override void Interact()
    {
        base.Interact();
        PlayerPrefs.SetInt("hs", _highscore);
        Debug.Log("Saved hs : " + _highscore);
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
}
