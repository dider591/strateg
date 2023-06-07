using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;
    [SerializeField] private bool _isReady;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_targetPoint != null)
        {
            if (other.TryGetComponent<ISetTargetPoint>(out ISetTargetPoint isetTargetPoint))
            {
                isetTargetPoint.SetTargetPoint(_targetPoint.position);
            }
        }
    }

    private void Update()
    {
        if (_targetPoint != null)
        {
            if (_isReady)
            {
                StartCoroutine(InstantiateUnits());
            }
        }
        else
        {
            SearchTargetPoint();
        }
    }

    public void SetReady(bool isReady)
    {
        _isReady = isReady;

    }

    private IEnumerator InstantiateUnits()
    {
        _isReady = false;

        for (int i = 0; i < _countWaves; i++)
        {
            for (int a = 0; a < _countUnit; a++)
            {
                Instantiate(_unit, _transform.position, _transform.rotation);
            }

            yield return new WaitForSeconds(_stepSpawn);
        }
    }

    private void SearchTargetPoint()
    {
        _targetPoint = FindObjectOfType<SoldierTargetPoint>().transform;
    }
}
