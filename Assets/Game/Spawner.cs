using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;

    protected Vector3 _crashedPoint;
    private bool _isAllCreated;
    private bool _isInit;

    public void Init(Vector3 crashedPoint)
    {
        _crashedPoint = crashedPoint;
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit && !_isAllCreated)
        {
            StartCoroutine(InstantiateUnits());
        }
    }

    private IEnumerator InstantiateUnits()
    {
        _isAllCreated = true;

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
