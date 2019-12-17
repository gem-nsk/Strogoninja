using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworder : MonoBehaviour
{
    public GameObject Sword;
    
  
    void Start()
    {
    }
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            float mousex = (Input.mousePosition.x);
            float mousey = (Input.mousePosition.y);
            // 5 in z to be in the front of the camera, but up to you, just avoid 0
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 5));
            Sword.transform.position = mouseposition;
        }

    }

}



















//Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//  if (Input.GetMouseButtonUp(0))
// {
//  RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
//if (Physics.Raycast(rayHit)
//Instantiate(Sword);
//Debug.Log("Selected object: " + rayHit.transform.name);
//  }





//private Vector3 screenPoint;
// private Vector3 offset;

//public RaycastHit hit;
//public Ray ray;


// void Update()
//{
// if (Input.GetMouseButtonDown(0))
//    Debug.Log("Проверка");
//   ray = Camera.main.ScreenPointToRay(Input.mousePosition);
// Transform objectHit = hit.transform;
// Instantiate(Sword);
// }




//void OnMouseDown()
// {

//  offset = Sword.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//}
//void OnMouseDrag()
// {
//Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
// transform.position = curPosition;
// }



