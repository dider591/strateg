using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainTarget : Unit, ITakeDamage
{
    private float _health;

    public UnityAction<float> HealthChanged;
    public UnityAction Healed;
    public UnityAction GameOver;

    private float _maxHealth = 1f;
    private float _minHealth = 0;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= (float)damage / 1000f;
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Death();
        }
    }

    public void Healing(int healing)
    {
        _health += (float)healing / 1000f;
        HealthChanged?.Invoke(_health);

        if (_health >= _maxHealth)
        {
            Healed?.Invoke();
            _health = _maxHealth;
        }
    }

    public override void Death()
    {
        GameOver?.Invoke();
    }

    public override void SearchTarget()
    {
    }
}
