using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knopki : MonoBehaviour
{
    public GameObject TheGame;
    public GameObject StartGame;
    public GameObject Lose;

     public void OnMouseDownAsButton()
     {
        SceneManager.LoadScene("SampleScene");
        TheGame.SetActive(true);
        StartGame.SetActive(false);
        Lose.SetActive(false);
        Debug.Log("Выполнен рестарт");
     }  


}
