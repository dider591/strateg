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
            _agent.enabled = false;
            _animator.Play(IdleAnimation);
            return TaskStatus.Success;
        }

        _agent.enabled = true;
        return TaskStatus.Failure;
    }

}
