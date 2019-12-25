using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : ObjectInteractionBasement
{
    public bool Active;

    public override void Init()
    {
        base.Init();
        if (Active)
        {
            StartCoroutine(Play());
            _Logic._knife.UntrackMouse();
        }
    }

    public override void DeActivate()
    {
        base.DeActivate();
        StopCoroutine(Play());
        _Logic._knife.TrackMouse();
    }

    IEnumerator Play()
    {
        while (true)
        {
            ObjectInteractionBasement enemy = _Logic._spawner.GetCurrentEnemy();

            if (enemy != null)
            {
                //cut enemy

                _Logic._knife.transform.position = new Vector3(enemy.transform.position.x - 3, enemy.transform.position.y);
                yield return null;
                _Logic._knife.transform.position = new Vector3(enemy.transform.position.x + 3, enemy.transform.position.y);
                yield return null;
            }
            else
            {
                //cut object
                _Logic._knife.transform.position = Vector3.Lerp( new Vector3(_Logic._object.transform.position.x - 3, _Logic._object.transform.position.y), new Vector3(_Logic._object.transform.position.x + 3, _Logic._object.transform.position.y), 0);
                yield return new WaitForEndOfFrame();
                _Logic._knife.transform.position = Vector3.Lerp(new Vector3(_Logic._object.transform.position.x - 3, _Logic._object.transform.position.y), new Vector3(_Logic._object.transform.position.x + 3, _Logic._object.transform.position.y), 1);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
