using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Quaternion;


public class Run : MonoBehaviour
{
    public Transform target;
    public GameObject Spriteclick;
    public GameObject Cube;
    public float fast;


    void Start()
    {
        if (Spriteclick)
        {
            target = GameObject.FindWithTag("qwer").transform;
        }
    }


    public void Update()
    {
        if (Spriteclick)
        {
            transform.position = Vector2.MoveTowards(transform.position, Spriteclick.transform.position, fast * Time.deltaTime);
        }
        
        if (Spriteclick)
        {
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(target.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle - 90);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
		 if (Spriteclick)
        {
            Destroy(Cube);
            Debug.Log("Удалить птицу");
        }
		
    }

}


    







