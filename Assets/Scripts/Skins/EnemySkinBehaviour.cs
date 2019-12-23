using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

[CreateAssetMenu(fileName = "New Enemy", menuName = "New Enemy Skin")]
public class EnemySkinBehaviour : ScriptableObject
{
    public EnemySkin _data;

    public _Skin GetData()
    {
        return _data;
    }
}
