﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

namespace Skin
{
    [System.Serializable]
    public class _Skin
    {
        [Header("Shop settings")]
        public int _Price;
        public enum _SkinType
        {
            Object = 0,
            Enemy = 1,
            Knife = 2
        }
    }

    #region Skins
    [System.Serializable]
    public class ObjectSkin : _Skin
    {
        [Header("Object Setting")]
        [Space(10)]
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
        [Header("Enemy Setting")]
        [Space(10)]
        public EnemyScriptableObject EnemyData;
    }

    [System.Serializable]
    public class KnifeSkin : _Skin
    {
        [Header("Knife Settings")]
        [Space(10)]
        public Gradient _KnifeColor;
    }

    #endregion

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
        public SkinKnifeBehaviour[] _KnifeSkin;
    }
}

public class SkinController : ObjectInteractionBasement
{
    public ObjectInteractionBasement _ObjectSkin;
    public ObjectInteractionBasement _EnemySkin;
    public ObjectInteractionBasement _KnifeSkin;

    public GameSkins _skinsBehaviour;

    public override void Init()
    {
        base.Init();
        _ObjectSkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._ObjectSkin[0].GetData());
        _EnemySkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._EnemySkin[0].GetData());
        _KnifeSkin.GetComponent<ISkinHolder>().SetSkinObject(_skinsBehaviour._KnifeSkin[0].GetData());
    }
}