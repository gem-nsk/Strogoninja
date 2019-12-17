using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Deathscreen : ObjectInteractionBasement
{
    public Text _scoreText;
    public Text _bestText;

    public override void Init()
    {
        base.Init();
        _scoreText.text = "Score: " + GameLogic.instance._Score._Score;
        _bestText.text = "Best: " + GameLogic.instance._Score._highscore;
    }
}
