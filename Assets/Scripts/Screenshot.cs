using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown( KeyCode.Space))
        {
            string path = Application.persistentDataPath + "/Screen_" + Random.Range(0, 10000) + ".png";
            Debug.Log(path);
            ScreenCapture.CaptureScreenshot(path);
        }
    }
}
