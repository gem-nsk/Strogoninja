using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

namespace Skin
{
    [System.Serializable]
    public class _Skin
    {
    }

    [System.Serializable]
    public class ObjectSkin : _Skin
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

    [System.Serializable]
    public class EnemySkin : _Skin
    {
        public EnemyScriptableObject EnemyData;
    }

    public interface ISkinHolder
    {
        void SetSkinObject(_Skin obj);
        void UpdateSkin();
    }

    [System.Serializable]
    public class GameSkins
    {
        public SkinObjectBehaviour[] _ObjectSkin;
        public EnemySkinBehaviour[] _EnemySkin;
    }
}

public class SkinController : ObjectInteractionBasement
{
    public ObjectInteractionBasement _ObjectSkin;
    public ObjectInteractionBasement _EnemySkin;

    public GameSkins _skinsBehaviour;

    public override void Init()
    {
        base.Init();
        _ObjectSkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._ObjectSkin[0].GetData());
        _EnemySkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._EnemySkin[0].GetData());
    }
}
