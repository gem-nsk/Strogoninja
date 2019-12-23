using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

[CreateAssetMenu(fileName = "New Object Skin", menuName = "Skin/New Object Skin")]
public class SkinObjectBehaviour : ScriptableObject
{
    public  ObjectSkin _Data;

    public _Skin GetData()
    {
        return _Data;
    }
}
