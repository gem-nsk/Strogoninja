using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class Shop : ObjectInteractionBasement
{

    public ShopUI _ui;
    public SkinController _skins { get { return _Logic._Skins; } }

    public List<_Skin> _CurrentSkins = new List<_Skin>();

    public override void Init()
    {
        base.Init();
        _ui.gameObject.SetActive(true);
        _CurrentSkins.Clear();

        _ui.Init();
    }

    public override void DeActivate()
    {
        base.DeActivate();
        _ui.DeActivate();
        _ui.gameObject.SetActive(false);
    }

    public void ChangeCategory(_Skin._SkinType type)
    {
        ClearSkins();
        switch (type)
        {
            case _Skin._SkinType.Enemy:
                Debug.Log("Switched to enemy");
                LoadCategory(_Logic._Skins._skinsBehaviour._EnemySkin);
                break;

            case _Skin._SkinType.Knife:
                Debug.Log("Switched to knife");
                LoadCategory(_Logic._Skins._skinsBehaviour._KnifeSkin);
                break;

            case _Skin._SkinType.Object:
                Debug.Log("Switched to object");
                LoadCategory(_Logic._Skins._skinsBehaviour._ObjectSkin);
                break;
        }
    }

    void LoadCategory(EnemySkinBehaviour[] _id)
    {
        Debug.Log(_id.Length);
        for (int i = 0; i < _id.Length; i++)
        {
            _CurrentSkins.Add(_id[i].GetData());
        }

        _ui.FillGrid(_Skin._SkinType.Enemy);
    }
    void LoadCategory(SkinObjectBehaviour[] _id)
    {
        Debug.Log(_id.Length);
        for (int i = 0; i < _id.Length; i++)
        {
            _CurrentSkins.Add(_id[i].GetData());
        }

        _ui.FillGrid(_Skin._SkinType.Object);
    }
    void LoadCategory(SkinKnifeBehaviour[] _id)
    {
        Debug.Log(_id.Length);
        for (int i = 0; i < _id.Length; i++)
        {
            _CurrentSkins.Add(_id[i].GetData());
        }

        _ui.FillGrid(_Skin._SkinType.Knife);
    }

    private void ClearSkins()
    {
        _CurrentSkins.Clear();
        _ui.ClearShop();
    }

    public void InteractWithElement(ShopElement _element)
    {

    }
}
