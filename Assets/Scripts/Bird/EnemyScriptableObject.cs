using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new enemy", menuName = "Enemy/New enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public Sprite[] SpriteSheet;
    public ParticleSystem DeathParticles;
    public float BaseSpeed = 5;
    public AnimationCurve MovingCurve;
}
