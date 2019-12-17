using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : ObjectInteractionBasement
{
    public GameObject prefab;
    private GameObject _currentPrefab;
    public float StartDelay;
    public float Delay;
    private bool _spawn;

    public override void Init()
    {
        base.Init();
        if(_currentPrefab)
        {
            Destroy(_currentPrefab);
        }
        _spawn = true;
        Interact();
    }
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(SpawnEnemys());
    }
    public override void DeActivate()
    {
        base.DeActivate();
        _spawn = false;
        if (_currentPrefab)
            Destroy(_currentPrefab);
    }

    public IEnumerator SpawnEnemys()
    {
        yield return new WaitForSeconds(StartDelay);
        while(_spawn)
        {
            if(_currentPrefab == null)
            {
                yield return new WaitForSeconds(Delay);
                GameObject obj = Instantiate(prefab);

                obj.transform.position = GetPos();
                EnemyInteractionBasement enemy = obj.GetComponent<EnemyInteractionBasement>();

                enemy.Init(GameLogic.instance._object.transform, enemy.behaviour.BaseSpeed);

                _currentPrefab = obj;
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
