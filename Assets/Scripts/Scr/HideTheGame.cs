using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTheGame : MonoBehaviour
{
    public GameObject Spriteclick;
    public GameObject Lose;
    public GameObject TheGame;
    public GameObject GameMusic;

    void Update()
    {
        if (Spriteclick == null)
        {
            Lose.SetActive(true);
            TheGame.SetActive(false);
            GameMusic.SetActive(false);
        }

    }
}
