using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackCarTransition : SoldierConditional
{
    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target != null)
        {
                return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
