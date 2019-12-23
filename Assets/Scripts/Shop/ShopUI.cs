using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Skin;

public class ShopUI : ObjectInteractionBasement
{
    private Shop _shop { get { return _Logic._Shop; } }

    private bool _IsInited;
    public Button[] _Categories;

    public override void Init()
    {
        base.Init();

        if (!_IsInited)
        {
            //first setup
            //...
            SetButtonsCategories();
        }

        //Update Shop
        Interact();

        _IsInited = true;
    }

    public override void Interact()
    {
        base.Interact();
        //update shop statements
    }

    private void SetButtonsCategories()
    {
        for (int i = 0; i < _Categories.Length; i++)
        {
            switch (i)
            {
                case 0:
                    _Categories[i].onClick.AddListener(() => ChangeCategory(_Skin._SkinType.Object));
                    break;
                case 1:
                    _Categories[i].onClick.AddListener(() => ChangeCategory(_Skin._SkinType.Enemy));
                    break;
                case 2:
                    _Categories[i].onClick.AddListener(() => ChangeCategory(_Skin._SkinType.Knife));
                    break;
            }
        }
    }

    public void ChangeCategory(_Skin._SkinType type)
    {
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
    }
    void LoadCategory(SkinObjectBehaviour[] _id)
    {
        Debug.Log(_id.Length);
    }
    void LoadCategory(SkinKnifeBehaviour[] _id)
    {
        Debug.Log(_id.Length);
    }
}
