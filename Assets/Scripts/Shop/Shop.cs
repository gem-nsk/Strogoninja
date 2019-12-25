using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class Shop : ObjectInteractionBasement
{
    public enum _ElementType
    {
        Unlocked,
        Blocked
    }

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
        Debug.Log("ui_interactWithElement");
        switch (CheckForBuying(_element))
        {
            case _ElementType.Unlocked:
                Debug.Log("case unlocked");
                _Logic._Skins.SetSkin(_element._skin);
                _ui.SetFocusedElement(_element);
                break;

            case _ElementType.Blocked:
                Debug.Log("case blocked");

                if (BuyElement(_element))
                {
                    _Logic._Skins.SetSkin(_element._skin);
                    _ui.SetFocusedElement(_element);
                }
                break;
        }
    }

    public _ElementType CheckForBuying(ShopElement _element)
    {
        //if already unlocked
        if (_element._skin._Unlocked)
        {
            return _ElementType.Unlocked;
        }
        //check for price
        else
        {
            return _ElementType.Blocked;
        }
    }

    public bool BuyElement(ShopElement _element)
    {
        if(_Logic._Score._Coins >= _element._skin._Price)
        {
            Debug.Log("Buy!");
            _Logic._Score.AddCoins(-_element._skin._Price);
            _element._skin._Unlocked = true;

            return true;
        }
        else { return false; }
    }
}
