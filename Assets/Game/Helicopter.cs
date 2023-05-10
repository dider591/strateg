using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class Helicopter : MainTarget, ITakeDamage, IGameOver
{
    private float _health;

    private float _maxHealth = 1f;
    private float _minHealth = 0;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= (float)damage / 1000f;
        ProgressChanged?.Invoke(_health);
        GameOver();
    }

    public void Healing(float healing)
    {
        _health += healing;
        ProgressChanged?.Invoke(_health);
        GameOver();
    }

    public void GameOver()
    {
        if (_health <= _minHealth)
        {
            Defeat?.Invoke();
        }
        if (_health >= _maxHealth)
        {
            Win?.Invoke();
        }
    }
}
