using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent Tap;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Tap != null)
            {
                Tap.Invoke();
            }
        }

        foreach(Touch t in Input.touches)
        {
            if(t.phase == TouchPhase.Began)
            {
                if(Tap != null)
                {
                    Tap.Invoke();
                }
            }
        }
    }
}
