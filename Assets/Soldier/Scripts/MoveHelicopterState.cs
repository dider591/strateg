using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveHelicopterState : SoldierAction
{
    private int Run = Animator.StringToHash("Run");

    public override void OnStart()
    {
        Debug.Log("MoveHelicopterState");
    }

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
        transform.LookAt(point);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        _animator.Play(Run);
        _agent.SetDestination(point);
    }
}
