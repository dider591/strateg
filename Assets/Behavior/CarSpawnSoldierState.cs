using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CarSpawnSoldierState : UnitAction
{
    [SerializeField] private Spawner _spawner;

    private bool _isAllSpawn = false;

    public override TaskStatus OnUpdate()
    {
        if (_isAllSpawn == false)
        {
            _isAllSpawn = true;
            _spawner.SetReady(true);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
