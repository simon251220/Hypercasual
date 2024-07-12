using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action onKill;

    public float startLife = 10;
    private float _currentLife;

    public bool destroyOnKill = false;

    private bool _isDead = false;

    public float delayToKill = 0f;
    private FlashColor _flashColor;

    private void Awake()
    {
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }

        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }

        /*if(_flashColor != null)
        {
            _flashColor.Flash();
        }*/
    }

    public void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(this.gameObject, delayToKill);
        }

        onKill?.Invoke();
    }
}
