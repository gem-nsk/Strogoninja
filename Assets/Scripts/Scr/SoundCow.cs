using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCow : MonoBehaviour
{
    public GameObject PartPosCow;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(Instantiate(PartPosCow, transform.position, Quaternion.identity), 1f);
    }
}
