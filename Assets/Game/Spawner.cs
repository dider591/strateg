using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;
    [SerializeField] private bool _isReady;

    protected Vector3 CrashedPoint;
    private bool _isInit;

    public void Init(Vector3 crashedPoint)
    {
        CrashedPoint = crashedPoint;
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit && _isReady)
        {
            StartCoroutine(InstantiateUnits());
        }
    }

    public void SetReady()
    {
        _isReady = true;
    }

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
