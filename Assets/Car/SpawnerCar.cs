using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : Spawner
{
    private void OnTriggerEnter(Collider other)
    {
        if (_crashedPoint != null)
        {
            if (other.TryGetComponent<Car>(out Car car))
            {
                car.SetCrashPoint(_crashedPoint);
            }
        }
    }
}
