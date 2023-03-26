using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SoldierAttackState : UnitAction
{
    [SerializeField] private Transform _ShootPoint;

    private int ShootAnimation = Animator.StringToHash("Shoot");
    private float _range = 6f;

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
        //RaycastHit hit;

        //if (Physics.Raycast(_ShootPoint.position, _ShootPoint.transform.forward, out hit, _range))
        //{
        //    if (hit.collider.gameObject != _unit.CurrentTarget)
        //    {
        //        _unit.SearchTarget();
        //    }

        _animator.Play(ShootAnimation);
        //}
    }
}
