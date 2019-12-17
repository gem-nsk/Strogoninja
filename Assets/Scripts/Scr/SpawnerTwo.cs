using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTwo : MonoBehaviour
{
    public GameObject Spriteclick;
    public Transform[] SpawnPosTwo;
    public GameObject Cube;
    public float TimeSpawnTwo;
    public int i;

    void Start()
    {
      StartCoroutine(SpawnDC());
    }

    void Repeat()
    {
        if (Spriteclick)
        {
            StartCoroutine(SpawnDC());
        }
    }

    IEnumerator SpawnDC()
    {

        TimeSpawnTwo = Random.Range(5f, 9f);
        yield return new WaitForSeconds(TimeSpawnTwo);
        int rty = Random.Range(0, SpawnPosTwo.Length);
        Cube.GetComponent<Run>().fast = Random.Range(12f, 12f);
        Destroy(Instantiate(Cube, SpawnPosTwo[rty].position, transform.rotation), 10f);
        Repeat();
    }

}

