using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleState : SoldierAction
{
    private int IdleAnimation = Animator.StringToHash("Idle");

    public override void OnStart()
    {
        Debug.Log("IdleState");
    }

    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target == null)
        {
            _animator.Play(IdleAnimation);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

}
