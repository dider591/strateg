using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnState : SoldierAction
{
    [SerializeField] private Spawner _spawner;

    public override TaskStatus OnUpdate()
    {
        if (Unit.Target == null)
        {
            Agent.SetDestination(transform.position);
            _spawner.SetReady(true);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
