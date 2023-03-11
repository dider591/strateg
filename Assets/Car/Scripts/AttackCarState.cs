using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackCarState : SoldierAction
{
    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target != null)
        {
            transform.LookAt(_soldier.Target.transform.position);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
