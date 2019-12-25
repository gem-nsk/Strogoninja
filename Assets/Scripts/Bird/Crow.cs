using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : EnemyInteractionBasement
{
    public override void Death()
    {
        base.Death();
        Transform obj = Instantiate(behaviour.EnemyData.DeathParticles).transform;
        obj.position = new Vector3(transform.position.x, transform.position.y, -3);

        _Logic._Score.AddTempCoins(1);

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("bird reached target!");
            _Logic.Loose();
        }
    }
}
