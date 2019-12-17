using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : ObjectInteractionBasement
{
    private bool _isOn;
    private Vector3 _oldPos;

    public override void Init()
    {
        base.Init();
        _isOn = true;
        StartCoroutine(Follow());
    }
    public override void DeActivate()
    {
        base.DeActivate();
        _isOn = false;
    }

    IEnumerator Follow()
    {
        while(_isOn)
        {
#if UNITY_EDITOR
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));

#elif UNITY_ANDROID


#endif
            if(Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 5));
            }
            yield return null;
        }
    }

    private void Update()
    {
        if(_isOn)
        {
            _oldPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isOn)
        {
            if(_oldPos != transform.position)
            {
                collision.GetComponent<ObjectInteractionBasement>().Interact();
                Debug.Log(collision.name + " object");

            }
        }
    }
}
