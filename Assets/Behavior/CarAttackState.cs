using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CarAttackState : UnitAction
{
    [SerializeField] private Transform _machingunner;
    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            _machingunner.LookAt(_unit.CurrentTarget.transform.position);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
