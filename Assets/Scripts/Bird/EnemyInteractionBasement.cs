using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractionBasement : ObjectInteractionBasement, ISkinHolder
{
    public EnemyScriptableObject behaviour;
    public SpriteRenderer rend;
    public float _SpriteSheetSpeed;


    public override void Interact()
    {
        base.Interact();
        Death();
    }

    public virtual void Init(Transform target, float Time)
    {
        StartCoroutine(SpriteAnimate());
        StartCoroutine(MoveTo(target, Time));
    }

    public virtual IEnumerator MoveTo(Transform target, float time)
    {
        Vector3 origin = transform.position;
        float _time = 0;
        float _State;
        float dist =  Vector2.Distance(origin, target.position);

        Vector2 maxVec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 5));

        while (transform.position != target.position)
        {
            _State = _time / time;

            transform.position = Vector3.Lerp(origin, target.position, _State);
            Vector3 relative = transform.InverseTransformPoint(target.position);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle - 90);

            if (transform.rotation.z < 270 && transform.rotation.z > 90)
            {
                rend.flipY = true;
            }
            else
                rend.flipY = false;

            _time += (dist / maxVec.magnitude) * (Time.deltaTime / _Logic._Level._Settings._SpeedModifier);
            yield return null;
        }
    }

    public virtual void Death()
    {

    }

    public virtual IEnumerator SpriteAnimate()
    {
        while(true)
        {
            foreach(Sprite _sprite in behaviour.SpriteSheet)
            {
                rend.sprite = _sprite;
                yield return new WaitForSeconds(_SpriteSheetSpeed);
            }
        }
    }

    public void SetSkinObject(SkinObject obj)
    {
        for (int i = 0; i < obj.GetSprites().Length; i++)
        {
            behaviour.SpriteSheet[i] = obj.GetSprites()[i];
        }
    }

    public void UpdateSkin()
    {
    }
}
