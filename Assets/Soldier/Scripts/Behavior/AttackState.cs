using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackState : SoldierAction
{
    private int ShootAnimation = Animator.StringToHash("Shoot");

    public override void OnStart()
    {
        Debug.Log("AttackState");
    }


    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target != null)
        {
            _agent.SetDestination(transform.position);

            transform.LookAt(_soldier.Target.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            Shoot();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private void Shoot()
    {
        _animator.Play(ShootAnimation);
    }
}
