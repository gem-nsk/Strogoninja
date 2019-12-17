using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Spriteclick;
    public bool enter = true;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (enter)
        {
            Debug.Log("Рыбка уничтожена");
            Destroy(Spriteclick);
        }


    }      
}

