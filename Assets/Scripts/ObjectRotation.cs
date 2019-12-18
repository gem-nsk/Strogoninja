using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : ObjectInteractionBasement
{
    public ParticleSystem _Particle;
    public Transform obj;
    public float Speed;
    private bool _IsOn;

   public override void Init()
    {
        if(!_IsOn)
        {
            _IsOn = true;
            _hitSpeed = 1;
            StartCoroutine(Rotate());
        }
    }

    public override void DeActivate()
    {
        _IsOn = false;
    }

    public void SetPosition(Vector2 vector)
    {
        transform.position = vector;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    float _hitSpeed;
    IEnumerator Rotate()
    {

        while(_IsOn)
        {
            obj.Rotate(new Vector3(0, 0, _hitSpeed * Speed * Time.deltaTime * 10));
            _hitSpeed -= Time.deltaTime;
            _hitSpeed = Mathf.Clamp(_hitSpeed, 1, 6);
            yield return null;
        }
        float _stopTime = 0.6f;
        while(_stopTime > 0)
        {
            obj.Rotate(new Vector3(0, 0, _hitSpeed * Speed * Time.deltaTime * 10));
            _hitSpeed = _stopTime;
            _stopTime -= Time.deltaTime;
            yield return null;
        }
    }

    public override void Interact()
    {
        base.Interact();
        _Particle.Play();
        _hitSpeed += 0.5f;
        _Logic._Score.Add();
        _Logic._Music.PlayTargetCut();
    }
}
