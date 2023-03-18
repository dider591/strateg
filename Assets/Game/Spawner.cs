using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;
    [SerializeField] private bool _isReady;

    protected Transform TargetPoint;
    protected Transform _currentTransform;

    private Helicopter _helicopter;

    public bool IsReady => _isReady;

    private void Awake()
    {
        FindTargetPoint();       
    }

    private void OnEnable()
    {
        _helicopter = FindObjectOfType<Helicopter>();
        _helicopter.Crashed += StartSpawn;
    }

    private void OnDisable()
    {
        _helicopter.Crashed -= StartSpawn;
    }

    public void SetReady(bool isReady)
    {
        _isReady = isReady;
    }

    public void StartSpawn()
    {
        if (_isReady)
        {
            StartCoroutine(nameof(InstantiateUnits));
        }
    }

    public abstract void FindTargetPoint();

    private IEnumerator InstantiateUnits()
    {
        _isReady = false;

        for (int i = 0; i < _countWaves; i++)
        {
            for (int a = 0; a < _countUnit; a++)
            {
                Instantiate(_unit, transform.position, transform.rotation);
            }

            yield return new WaitForSeconds(_stepSpawn);
        }
    }
}
