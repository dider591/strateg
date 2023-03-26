using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetPointState : UnitAction
{
    private int Run = Animator.StringToHash("Run");

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget == null && _unit.CurrentTargetPoint != null)
        {
            MoveToPoint(_unit.CurrentTargetPoint);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    private void MoveToPoint(Vector3 point)
    {
        _animator.Play(Run);
        _agent.SetDestination(point);
    }
}
