using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    //public Transform[] StrogPos;
    //public GameObject stroganina1;
    public Text scoreTextLose;
    public Text scoreTextLoseOne;
    public Text scoreText;
    public int score;
    public int record;

    public void Start()
    {

    }

    public void OnClick()
    {
        score++;
        scoreText.text = "" + score;
        scoreTextLoseOne.text = scoreText.text;
    }

    public void Update()
    {
        if (score>record)   
        { 
           PlayerPrefs.SetInt("savedScore", score);
           PlayerPrefs.Save();
        }
        record = PlayerPrefs.GetInt("savedScore");
        scoreTextLose.text = "" + record.ToString();
    }










}

