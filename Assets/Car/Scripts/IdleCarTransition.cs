using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class IdleCarTransition : SoldierConditional
{
    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target == null)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
