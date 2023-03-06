using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSoldiers : Spawner
{
    private void OnTriggerEnter(Collider other)
    {
        if (CrashedPoint != null)
        {
            if (other.TryGetComponent<Soldier>(out Soldier soldier))
            {
                soldier.SetCrashPoint(CrashedPoint);
            }
        }
    }
}
