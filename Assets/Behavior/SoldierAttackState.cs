using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SoldierAttackState : UnitAction
{
    private int ShootAnimation = Animator.StringToHash("Shoot");

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            _agent.SetDestination(transform.position);

            transform.LookAt(_unit.CurrentTarget.transform.position);
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
