using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : ObjectInteractionBasement
{
    private bool _isOn;
    private Vector3 _oldPos;
    public Collider2D _OldCollider;
    public LayerMask mask;
    public float _ThresholdDistance;

    public override void Init()
    {
        base.Init();
        _isOn = true;
        _oldPos = transform.position;
        StartCoroutine(Follow());
    }
    public override void DeActivate()
    {
        base.DeActivate();
        Debug.Log("Knife deactivated");
        _isOn = false;
    }

    IEnumerator Follow()
    {
        while(_isOn)
        {
            //set knife postion
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));

            if(Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 5));
            }


            //check with previous position
            if (isPosChanged(_oldPos, transform.position))
            {
                Collider2D _Col = CheckObjectsPerPositions(_oldPos, transform.position);
                if (_OldCollider != _Col)
                {
                    if (_Col != null)
                    {
                        _Col?.GetComponent<ObjectInteractionBasement>()?.Interact();
                    }
                    _OldCollider = _Col;
                }
            }

            //set new previous position
            yield return new WaitForSeconds(0.02f);
            _oldPos = transform.position;

        }
    }

   

    Collider2D CheckObjectsPerPositions(Vector2 _old, Vector2 _new)
    {
        if(Vector2.Distance(_old, _new) > _ThresholdDistance)
        {
            RaycastHit2D hit;
            hit = (Physics2D.Linecast(_old, _new, mask));

            if (hit.collider != null)
            {
                return hit.collider;
            }
            else { return null; }
        }
        else { return null; }
    }

    bool isPosChanged(Vector2 _old, Vector2 _new)
    {
        if(_old != _new)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    private void OnDrawGizmos()
    {
        
            Gizmos.color = Color.red;
        Gizmos.DrawLine(_oldPos, transform.position);
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    return;
    //    if(_isOn)
    //    {
    //        if(_oldPos != transform.position)
    //        {
    //            collision.GetComponent<ObjectInteractionBasement>().Interact();
    //            Debug.Log(collision.name + " object");

    //        }
    //    }
    //}
}
