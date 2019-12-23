using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

[CreateAssetMenu(fileName = "New Skin", menuName = "New Skin")]
public class SkinObjectBehaviour : ScriptableObject
{
    public  ObjectSkin _Data;

    public virtual _Skin GetData()
    {
        return _Data;
    }
}
