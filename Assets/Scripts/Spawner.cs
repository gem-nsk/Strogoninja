using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class Spawner : ObjectInteractionBasement, ISkinHolder
{
    public GameObject[] prefabs;
    private GameObject _currentPrefab;
    public float StartDelay;
    public float Delay;
    private bool _spawn;

    public EnemySkin _EnemySkin;

    public override void Init()
    {
        base.Init();
        DeleteEnemy();
        _spawn = true;
        StartCoroutine(SpawnEnemys());
    }

    //spawn enemys
    public override void Interact()
    {
        if (_spawn)
        {
            base.Interact();
            Debug.Log("spawned enemy");
            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);

            Vector2 pos = GetPos();
            Debug.Log(pos.normalized);

            obj.transform.position = pos;

            if(pos.normalized.x < 0)
            {
                obj.GetComponent<SpriteRenderer>().flipY = true;
            }

            EnemyInteractionBasement enemy = obj.GetComponent<EnemyInteractionBasement>();

            enemy.Init(GameLogic.instance._object.transform, _EnemySkin.EnemyData.BaseSpeed);
            enemy.GetComponent<ISkinHolder>().SetSkinObject(_EnemySkin);

            _currentPrefab = obj;
        }
    }

    public override void DeActivate()
    {
        base.DeActivate();
        _spawn = false;
        
    }

    public void DeleteEnemy()
    {
        if (_currentPrefab != null)
            Destroy(_currentPrefab.gameObject);
    }

    public ObjectInteractionBasement GetCurrentEnemy() { return _currentPrefab?.GetComponent<ObjectInteractionBasement>(); }

    public IEnumerator SpawnEnemys()
    {
        yield return new WaitForSeconds(_Logic._Level._Settings._StartPenalty);
        while (_spawn)
        {
            if (_currentPrefab == null)
            {
                yield return new WaitForSeconds(Delay);
                Interact();
            }
            yield return null;
        }

        while(_spawn)
        {
            if(_currentPrefab == null)
            {
                yield return new WaitForSeconds(Delay);
                
            }
            yield return null;
        }
    }

   
    Vector3 GetPos()
    {
       return RandomPointOnCircleEdge(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5)));
    }

    private Vector3 RandomPointOnCircleEdge(Vector2 radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x * 1.4f, vector2.y * 1.7f, 0);
    }

    public void SetSkinObject(EnemySkin obj)
    {
        _EnemySkin = obj;
        UpdateSkin();
    }

    public void UpdateSkin()
    {

    }

    public void SetSkinObject(_Skin obj)
    {
        SetSkinObject((EnemySkin)obj);
    }

    public _Skin GetSkin()
    {
        return _EnemySkin;
    }
}
