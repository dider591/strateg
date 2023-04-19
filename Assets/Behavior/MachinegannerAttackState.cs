using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MachinegannerAttackState : UnitAction
{
    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            //_agent.SetDestination(transform.position);
            transform.LookAt(_unit.CurrentTarget.transform.position);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
