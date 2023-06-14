using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetUnitState : UnitAction
{
    private int Run = Animator.StringToHash("Run");

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            MoveToPoint(_unit.CurrentTarget.transform.position);
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
