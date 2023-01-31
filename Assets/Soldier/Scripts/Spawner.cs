using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private HelicopterMain _helicopterMain;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private int _countSoldier;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;

    private bool _isCrashed = false;
    private bool _isAllCreated = false;
    private Vector3 _crashedPoint;

    private void OnEnable()
    {
        _helicopterMain.CrashedPoint += OnHelicopterCrash;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_crashedPoint != null)
        {
            if (other.TryGetComponent<Soldier>(out Soldier soldier))
            {
                soldier.SetCrashPoint(_crashedPoint);
            }
        }
    }

    private void OnHelicopterCrash(Vector3 target)
    {
        _crashedPoint = target;
        _isCrashed = true;
    }

    private void Update()
    {
        if (_isCrashed && _isAllCreated == false)
        {
            _isAllCreated = true;
            StartCoroutine(InstantiateWaves());
        }
    }

    private IEnumerator InstantiateWaves()
    {
        for (int i = 0; i < _countWaves; i++)
        {
            for (int a = 0; a < _countSoldier; a++)
            {
                Instantiate(_soldier, transform.position, transform.rotation);
            }

            yield return new WaitForSeconds(_stepSpawn);
        }
    }

    private void OnDisable()
    {
        _helicopterMain.CrashedPoint -= OnHelicopterCrash;
    }
}
