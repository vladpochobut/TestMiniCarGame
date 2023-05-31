using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action OnGameEnds;
    public static event Action<float> OnHealthChenged;

    [SerializeField]
    private float _healthPoints = 100f;

    private float _maxHealthValue = 100f;
    private bool _isDead = false;
    private bool _isDamageBlocked = false;

    public void TakeDamage(float damage)
    {
        if (_isDamageBlocked)
            return;
        _healthPoints = Mathf.Max(_healthPoints - damage, 0);
        OnHealthChenged?.Invoke(_healthPoints);
        if (_healthPoints == 0)
        {
            Die();
        }
    }

    public void BlockDamage(bool isBlock)
    {
        _isDamageBlocked = isBlock;
    }

    public void TakeHealPoints(float healValue)
    {
        _healthPoints = Mathf.Min(_healthPoints + healValue, _maxHealthValue);
        OnHealthChenged?.Invoke(_healthPoints);
    }

    public void Die()
    {
        if (_isDead) return;
        OnGameEnds?.Invoke();
        _healthPoints = 0;
        _isDead = true;
    }
}
