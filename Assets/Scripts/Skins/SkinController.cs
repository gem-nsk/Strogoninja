using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinObject
{
    public Sprite[] _Sprites;

    public Sprite[] GetSprites()
    {
        return _Sprites;
    }

    public Sprite GetSprite()
    {
        return _Sprites[0];
    }
}

public interface ISkinHolder
{
    void SetSkinObject(SkinObject obj);
    void UpdateSkin();
}

[System.Serializable]
public class GameSkins
{
    public SkinObjectBehaviour[] _ObjectSkin;
    public SkinObjectBehaviour[] _EnemySkin; 
}

public class SkinController : ObjectInteractionBasement
{
    public ObjectInteractionBasement _ObjectSkin;
    public ObjectInteractionBasement _EnemySkin;

    public GameSkins _skinsBehaviour;

    public override void Init()
    {
        base.Init();
        _ObjectSkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._ObjectSkin[0]._Data);
        _EnemySkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._EnemySkin[1]._Data);
    }
}
