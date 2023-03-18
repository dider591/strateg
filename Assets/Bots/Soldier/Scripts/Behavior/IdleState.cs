using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleState : SoldierAction
{
    private int IdleAnimation = Animator.StringToHash("Idle");

    public override TaskStatus OnUpdate()
    {
        if (Unit.Target == null)
        {
            Agent.SetDestination(transform.position);
            Animator.Play(IdleAnimation);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

}
