using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTruck : Car
{
    [SerializeField] private Transform _spawnSoldierPoint;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private int _countSoldier;
    [SerializeField] private float _stepSpawn;


    private void OnTriggerEnter(Collider other)
    {
        if (_crashPoint != null)
        {
            if (other.TryGetComponent<Soldier>(out Soldier soldier))
            {
                soldier.SetCrashPoint(_crashPoint);
            }
            if (other.TryGetComponent<CarTargetPoint>(out CarTargetPoint carTargetPoint))
            {
                StartCoroutine(InstantiateSoldiers());
                _isInit = false;
                _agent.enabled = false;
            }
        }
    }

    private IEnumerator InstantiateSoldiers()
    {

        for (int i = 0; i < _countSoldier; i++)
        {
            yield return new WaitForSeconds(_stepSpawn);    
            Instantiate(_soldier, _spawnSoldierPoint.position, _spawnSoldierPoint.rotation);
        }
    }
}
