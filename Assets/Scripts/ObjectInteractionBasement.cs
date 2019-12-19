using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionBasement : MonoBehaviour
{
    protected GameLogic _Logic { get { return GameLogic.instance; } }
    public delegate void OnInteract();
    public OnInteract OnInteractHandler;

    public virtual void Init() { }
    public virtual void DeActivate() { }
    public virtual void Interact() { OnInteractHandler?.Invoke(); }
}
