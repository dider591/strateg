using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class MainTarget : MonoBehaviour, ITakeDamage
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

    public void Healing(float healing)
    {
        Debug.Log("Healing");
        _health += healing;
        HealthChanged?.Invoke(_health);

        if (_health >= _maxHealth)
        {
            Healed?.Invoke();
            _health = _maxHealth;
        }
    }

    public void Death()
    {
        GameOver?.Invoke();
    }
}
