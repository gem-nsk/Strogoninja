using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : EnemyInteractionBasement
{
    public override void Death()
    {
        base.Death();
        Transform obj = Instantiate(behaviour.DeathParticles).transform;
        obj.position = new Vector3(transform.position.x, transform.position.y, -3);
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("bird reached target!");
            GameLogic.instance.Loose();
        }
    }
}
