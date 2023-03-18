using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackMachineGunnerState : SoldierAction
{
    public override TaskStatus OnUpdate()
    {
        if (Unit.Target != null)
        {
            transform.LookAt(Unit.Target.transform.position);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
