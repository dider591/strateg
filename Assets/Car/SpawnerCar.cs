using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : Spawner
{
    [SerializeField] private Transform[] _carTargetPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (CrashedPoint != null)
        {
            if (other.TryGetComponent<Car>(out Car car))
            {
                if (_carTargetPoints.Length > 0)
                {
                    int randomPoint = (int)Random.Range(0f, _carTargetPoints.Length);
                    Transform _targetPoint = _carTargetPoints[randomPoint];
                    car.Init(CrashedPoint, _targetPoint);
                }
                else
                {
                    car.Init(CrashedPoint, _carTargetPoints[0]);
                }
            }
        }
    }
}
