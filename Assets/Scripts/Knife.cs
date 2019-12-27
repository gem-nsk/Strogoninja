using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class Knife : ObjectInteractionBasement, ISkinHolder
{
    private bool _isOn;
    private bool _TrackMousePos = true;
    private Vector3 _oldPos;
    public Collider2D _OldCollider;
    public LayerMask mask;
    public float _ThresholdDistance;
    public TrailRenderer _rend;

    private KnifeSkin _skin;

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

    public void UntrackMouse()
    {
        _TrackMousePos = false;
    }

    public void TrackMouse()
    {
        _TrackMousePos = true;
    }

    IEnumerator Follow()
    {
        while(_isOn)
        {
            if (_TrackMousePos)
            {
                //set knife postion
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));

                if (Input.touchCount > 0)
                {
                    Touch t = Input.GetTouch(0);
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 5));
                }
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
        DrawLine(_oldPos, transform.position, 8);
        
    }

    public static void DrawLine(Vector3 p1, Vector3 p2, float width)
    {
        int count = 1 + Mathf.CeilToInt(width); // how many lines are needed.
        if (count == 1)
        {
            Gizmos.DrawLine(p1, p2);
        }
        else
        {
            Camera c = Camera.current;
            if (c == null)
            {
                Debug.LogError("Camera.current is null");
                return;
            }
            var scp1 = c.WorldToScreenPoint(p1);
            var scp2 = c.WorldToScreenPoint(p2);

            Vector3 v1 = (scp2 - scp1).normalized; // line direction
            Vector3 n = Vector3.Cross(v1, Vector3.forward); // normal vector

            for (int i = 0; i < count; i++)
            {
                Vector3 o = 0.99f * n * width * ((float)i / (count - 1) - 0.5f);
                Vector3 origin = c.ScreenToWorldPoint(scp1 + o);
                Vector3 destiny = c.ScreenToWorldPoint(scp2 + o);
                Gizmos.DrawLine(origin, destiny);
            }
        }
    }

    public void SetSkinObject(_Skin obj)
    {
        SetSkinObject((KnifeSkin)obj);
    }

    public void SetSkinObject(KnifeSkin obj)
    {
        _skin = obj;
        UpdateSkin();
    }

    public void UpdateSkin()
    {
        if (_skin != null)
        {
            _rend.colorGradient = _skin._KnifeColor;
        }
    }

    public _Skin GetSkin()
    {
        return _skin;
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
