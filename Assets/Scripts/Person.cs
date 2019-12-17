using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : ObjectInteractionBasement
{
    public Sprite[] AnimationSprites;
    public SpriteRenderer rend;

    public override void Init()
    {
        base.Init();

    }
    public override void Interact()
    {
        StartCoroutine(ThrowAnim());

    }
    IEnumerator ThrowAnim()
    {
        foreach(Sprite s in AnimationSprites)
        {
            rend.sprite = s;
            yield return new WaitForSeconds(0.1f);
        }
        rend.sprite = AnimationSprites[0];
    }
}