using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleState : UnitAction
{
    private int IdleAnimation = Animator.StringToHash("Idle");

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget == null)
        {
            _agent.SetDestination(transform.position);
            _animator.Play(IdleAnimation);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

}
