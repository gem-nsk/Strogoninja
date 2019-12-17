using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SoundFish : MonoBehaviour
{
    public AudioSource _source;
    public AudioClip _fishsound;
    public bool vxod = true;
    public GameObject PartPos;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

     void OnTriggerEnter2D(Collider2D collaid)
    {
     	if(vxod)
     	{
       		 _source.PlayOneShot(_fishsound);
    		Destroy(Instantiate(PartPos, transform.position, Quaternion.identity), 1f);
     	}
    }
        
}
