using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetState : SoldierAction
{
    private int Run = Animator.StringToHash("Run");

    public override TaskStatus OnUpdate()
    {
        if (Unit.Target != null)
        {
            Agent.enabled = true;
            MoveToPoint(Unit.Target.transform.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    private void MoveToPoint(Vector3 point)
    {
        Animator.Play(Run);
        Agent.SetDestination(point);
    }
}
