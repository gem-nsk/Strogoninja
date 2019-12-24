﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopElement : ObjectInteractionBasement
{
    private ShopUI _ui { get { return _Logic._Shop._ui; } }
    public Text _Price_text;
    public GameObject _Price_bg;
    public Image _Object_Icon;

    
    public void Setup(bool isPurchased, int _price, Color _color, Sprite _icon = null)
    {
        if (isPurchased)
        {
            _Price_bg.SetActive(false);
        }
        else
        {
            _Price_bg.SetActive(true);
            _Price_text.text = _price.ToString();
        }

        if (_icon == null)
        {
            _Object_Icon.color = _color;
        }
        else
        {
            _Object_Icon.color = new Color(1, 1, 1, 1);
            _Object_Icon.sprite = _icon;
        }
    }

    public override void Interact()
    {
        _ui.ElementInteract(this);
    }
}