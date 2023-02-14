using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSoldier : Spawner
{
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
}
