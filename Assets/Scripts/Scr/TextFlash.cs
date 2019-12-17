using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
   public float clock;
   
    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= 0.5)
        {
        	GetComponent<Text> ().enabled =false;
        }
        if (clock >= 1)
        {
            GetComponent<Text> ().enabled =true;
            clock=0;
        }
    }
}
