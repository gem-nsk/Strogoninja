using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : ObjectInteractionBasement
{
    public Text _ScoreText;
    public GameObject _TapToStartText; 
    public Canvas_Deathscreen _Deathscreen;
    public GameObject _WinScreen;

    private bool _isOn;

    public override void Init()
    {
        base.Init();
        if (Score.AddScoreHandler == null)
        {
            Score.AddScoreHandler += UpdateScoreText;
        }
        _TapToStartText.SetActive(true);
        _Deathscreen.gameObject.SetActive(false);
        _isOn = true;
        StartCoroutine(BlinkStart());
    }

    public void InGame()
    {
        _isOn = false;
        _ScoreText.gameObject.SetActive(true);
        _TapToStartText.SetActive(false);
        _Deathscreen.gameObject.SetActive(false);
        _WinScreen.SetActive(false);
    }

    public void DeathScreen()
    {
        _ScoreText.gameObject.SetActive(false);
        _TapToStartText.SetActive(false);
        _Deathscreen.gameObject.SetActive(true);
        _Deathscreen.Init();
    }

    public void WinScreen()
    {
        _ScoreText.gameObject.SetActive(false);
        _TapToStartText.SetActive(false);
        _WinScreen.SetActive(true);
    }

    public void UpdateScoreText(int score)
    {
        _ScoreText.text = score + "/" + _Logic._Level._Settings._TargetPoints;
    }

    public IEnumerator BlinkStart()
    {
         while(_isOn)
        {
            _TapToStartText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _TapToStartText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
