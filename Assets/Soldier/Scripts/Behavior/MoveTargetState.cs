using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetState : SoldierAction
{
    private int Run = Animator.StringToHash("Run");

    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target != null)
        {
            MoveToPoint(_soldier.Target.transform.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    private void MoveToPoint(Vector3 point)
    {
        transform.LookAt(point);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        _animator.Play(Run);
        _agent.SetDestination(point);
    }
}
