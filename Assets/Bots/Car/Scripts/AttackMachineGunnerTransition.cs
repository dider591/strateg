using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackMachineGunnerTransition : SoldierConditional
{
    public override TaskStatus OnUpdate()
    {
        if (Unit.Target != null)
        {
                return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
