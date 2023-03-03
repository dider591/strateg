using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveHelicopterState : SoldierAction
{
    private int Run = Animator.StringToHash("Run");

    public override TaskStatus OnUpdate()
    {
        if (_soldier.CrashPoint != null)
        {
            MoveToPoint(_soldier.CrashPoint);
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
