using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class IdleMachineGunnerTransition : SoldierConditional
{
    public override TaskStatus OnUpdate()
    {
        if (Unit.Target == null)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
