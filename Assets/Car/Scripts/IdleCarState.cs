using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleCarState : SoldierAction
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
