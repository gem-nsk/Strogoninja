using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

[CreateAssetMenu(fileName = "new knife skin", menuName = "Skin/New Knife Skin")]
public class SkinKnifeBehaviour : ScriptableObject
{
    public KnifeSkin _data;

    public _Skin GetData()
    {
        return _data;
    }
}
