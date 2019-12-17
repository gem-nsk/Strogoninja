using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour { 
	
	public GameObject GameMusic;
	public GameObject ScoreHide;
    public GameObject StartGame;
    public GameObject TheGame;
    public GameObject White;
    public GameObject ManRun;
    public GameObject ManDownn;
    public GameObject ManDown;
    public GameObject FonNiz;
    public GameObject FonRun;
    public GameObject TheGameRun;
    public GameObject NameGameStart;
    public Transform target;
    public Transform targetfish;
    public Transform targetfon;
    public Transform targetgame;
    public GameObject FishUp;
    public GameObject FishRun;
    public GameObject TouchText;
    public float mrun = 3f;
    public float mrunn =50f;
    public float frun = 6f;
    public float fonrun =7f;
    public float gamerun =3f;
    
    void Start()
    {
        Invoke("Two", 1f);  

        //Invoke("One", 4f);
    }
  
    void Two()
    {
       White.SetActive(false);
    }

    public void OnMouseDownAsButtonStart()
    {
    	Invoke("Five", 0.01f);
    	Invoke("Six", 0.5f);
    	Invoke("Tree", 1.2f);
    }
    
    void Six()
    {
    	GameMusic.SetActive(true);
    }

    void Tree()
    {       
    	TheGame.SetActive(true);
        StartGame.SetActive(false);
        Debug.Log("Старт выполнен!");
    }
    
    void Five()
    {
    	ManDownn.GetComponent<Animator>().SetBool("Enter",true);
    	TouchText.SetActive(false);
    	NameGameStart.SetActive(false);
    	ScoreHide.SetActive(true);
    	
    }

    public void OnMouseDownAsButtonStartMan()
    {
        StartCoroutine(ManCD());
    }

    void Repeat()
    {
        StartCoroutine(ManCD());
    }

    IEnumerator ManCD()
    {
        yield return null;
        ManDownn.transform.position = Vector2.MoveTowards(ManDownn.transform.position, ManRun.transform.position, mrun * Time.deltaTime);
        ManDown.transform.position = Vector2.MoveTowards(ManDownn.transform.position, ManRun.transform.position, mrunn * Time.deltaTime);
        FishUp.transform.position = Vector2.MoveTowards(FishUp.transform.position, FishRun.transform.position, frun * Time.deltaTime);
        FishUp.transform.Rotate(new Vector3(0, 0, -5));
        FonNiz.transform.position = Vector2.MoveTowards(FonNiz.transform.position, FonRun.transform.position, fonrun * Time.deltaTime);
        NameGameStart.transform.position = Vector2.MoveTowards(NameGameStart.transform.position, TheGameRun.transform.position, gamerun * Time.deltaTime);

        Repeat();
    }

}


   	// public void One()
   	//StartCoroutine(StartGG());
   	// TheGame.SetActive(true);
   	// Debug.Log("Старт выполнен!");
  	 // StartGame.SetActive(false);
   	// }
  	 //void Repeat()
  	 //{
   	//  StartCoroutine(StartGG());
   	// }
	//IEnumerator StartGG()
	//{
	//  yield return new WaitForSeconds(1f);
	// TheGame.SetActive(true);
	//  Debug.Log("Старт выполнен!");
	// StartGame.SetActive(false);
	//   Repeat();
	//}





