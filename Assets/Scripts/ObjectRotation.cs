﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class ObjectRotation : ObjectInteractionBasement, ISkinHolder
{
    public ParticleSystem _Particle;
    public Transform obj;
    public float Speed;
    private bool _IsOn;

    public SpriteRenderer _rend;
    private ObjectSkin _skin;

    public override void Init()
    {
        if (!_IsOn)
        {
            _IsOn = true;
            _hitSpeed = 1;
            StartCoroutine(Rotate());

            UpdateSkin();

           
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
        if (_IsOn)
        {
            base.Interact();
            _Particle.Play();
            _hitSpeed += 0.5f;
            _Logic._Score.Add();
            _Logic._Music.PlayTargetCut();
        }
    }

    public void SetSkinObject(ObjectSkin obj)
    {
        _skin = obj;
        UpdateSkin();
    }

    public void UpdateSkin()
    {
        if(_skin != null)
        {
            _rend.sprite = _skin.GetSprite();
            if (_Particle != null)
            {
                Destroy(_Particle.gameObject);
            }
            GameObject particles = Instantiate(_skin._ActionParticles).gameObject;
            _Particle = particles.GetComponent<ParticleSystem>();
            _Particle.transform.position = new Vector3(0, 0, -2);
        }

    }

    public void SetSkinObject(_Skin obj)
    {
        SetSkinObject((ObjectSkin)obj);
    }

    public _Skin GetSkin()
    {
        return _skin;
    }
}
