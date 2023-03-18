using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleMachineGunnerState : SoldierAction
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
