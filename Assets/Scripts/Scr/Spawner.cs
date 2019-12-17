using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spriteclick;
    public Transform[] SpawnPos;
    public GameObject Cube;
    public float TimeSpawn;

    void Start()
    {
     StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        if (Spriteclick)
        {
          StartCoroutine(SpawnCD());
        }
    }

    IEnumerator SpawnCD()
    {

        TimeSpawn = Random.Range(1.5f, 3f);
        yield return new WaitForSeconds(TimeSpawn);
        int qwe = Random.Range(0, SpawnPos.Length);
        Cube.GetComponent<Run>().fast = Random.Range(20f, 22f);
        Destroy(Instantiate(Cube, SpawnPos[qwe].position, transform.rotation), 10f);

                                                                                      //if (Cube = null) //если включить эту функцию кубики летят в место нужное 1 раз 
        Repeat();
    }

}







