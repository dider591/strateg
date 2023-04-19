using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MachingannerIdleTransition : UnitConditional
{
    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget == null)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
