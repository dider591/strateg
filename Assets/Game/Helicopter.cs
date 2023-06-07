using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class Helicopter : MainTarget, ITakeDamage
{
    private float _health = 1f;

    private float _maxHealth = 1f;
    private float _minHealth = 0;
    private float _timeDelayTask = 4f;
    private float _deltaHealing = 0f;

    private void Start()
    {
        //_health = _maxHealth;
        Invoke(nameof(StartTaskMessage), _timeDelayTask);
    }

    public void TakeDamage(int damage)
    {
        _health -= (float)damage / 1000f;
        ProgressChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Defeat?.Invoke();
        }
    }

    public void Heal(float healing)
    {
        _health += healing;
        ProgressChanged?.Invoke(_health);
        Debug.Log(_health);

        if (_health >= _maxHealth)
        {
            Win?.Invoke();
        }
    }

    private void StartTaskMessage()
    {
        _taskMessage.Open();
    }
}
