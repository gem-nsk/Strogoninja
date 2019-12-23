using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : ObjectInteractionBasement
{

    public ShopUI _ui;
    public SkinController _skins { get { return _Logic._Skins; } }

    public override void Init()
    {
        base.Init();
        _ui.gameObject.SetActive(true);
        _ui.Init();
    }

    public override void DeActivate()
    {
        base.DeActivate();
        _ui.DeActivate();
        _ui.gameObject.SetActive(false);
    }
}
