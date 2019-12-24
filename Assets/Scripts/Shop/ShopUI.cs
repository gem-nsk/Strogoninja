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
    public GameObject _Prefab;
    public Transform Conteiner;

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
        _shop.ChangeCategory(_Skin._SkinType.Object);
    }

    private void SetButtonsCategories()
    {
        for (int i = 0; i < _Categories.Length; i++)
        {
            switch (i)
            {
                case 0:
                    _Categories[i].onClick.AddListener(() => _shop.ChangeCategory(_Skin._SkinType.Object));
                    break;
                case 1:
                    _Categories[i].onClick.AddListener(() => _shop.ChangeCategory(_Skin._SkinType.Enemy));
                    break;
                case 2:
                    _Categories[i].onClick.AddListener(() => _shop.ChangeCategory(_Skin._SkinType.Knife));
                    break;
            }
        }
    }

    ShopElement CreateShopElement()
    {
        GameObject obj = Instantiate(_Prefab, Conteiner);
        return obj.GetComponent<ShopElement>();
    }

    public void FillGrid(_Skin._SkinType _type)
    {
        switch (_type)
        {
            case _Skin._SkinType.Enemy:

                foreach(EnemySkin skin in _shop._CurrentSkins)
                {
                    CreateShopElement().Setup(skin, false, skin._Price, new Color(1,1,1,1), skin.EnemyData.SpriteSheet[0]);
                }

                break;

            case _Skin._SkinType.Knife:

                foreach (KnifeSkin skin in _shop._CurrentSkins)
                {
                    CreateShopElement().Setup(skin, false, skin._Price, skin._KnifeColor.Evaluate(0));
                }

                break;

            case _Skin._SkinType.Object:

                foreach(ObjectSkin skin in _shop._CurrentSkins)
                {
                    CreateShopElement().Setup(skin, false, skin._Price, new Color(1,1,1,1), skin._Sprites[0]);
                }

                break;
        }
    }

    public void ClearShop()
    {
        foreach (Transform child in Conteiner.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ElementInteract(ShopElement _element)
    {
        _shop.InteractWithElement(_element);
    }

    public override void DeActivate()
    {
        base.DeActivate();

    }
}
