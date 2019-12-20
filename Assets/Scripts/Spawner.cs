using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : ObjectInteractionBasement
{
    public GameObject[] prefabs;
    private GameObject _currentPrefab;
    public float StartDelay;
    public float Delay;
    private bool _spawn;

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

            obj.transform.position = GetPos();
            EnemyInteractionBasement enemy = obj.GetComponent<EnemyInteractionBasement>();

            enemy.Init(GameLogic.instance._object.transform, enemy.behaviour.BaseSpeed);

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
            _currentPrefab.GetComponent<EnemyInteractionBasement>().Interact();
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
}
