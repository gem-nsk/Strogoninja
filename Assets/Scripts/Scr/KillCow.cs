using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCow : MonoBehaviour
{
    public GameObject Cube;
    public AudioSource _urce;
    public AudioClip _diesound;


    void Start()
    {
     _urce = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D Cube)
    {
        if (Cube.gameObject.CompareTag("WorldM")) ;
             {
                 _urce.PlayOneShot(_diesound);
             }
    }








}
