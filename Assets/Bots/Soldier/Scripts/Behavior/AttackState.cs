using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackState : SoldierAction
{
    private int ShootAnimation = Animator.StringToHash("Shoot");

    public override TaskStatus OnUpdate()
    {
        if (Unit.Target != null)
        {
            Agent.SetDestination(transform.position);

            transform.LookAt(Unit.Target.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            Shoot();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private void Shoot()
    {
        Animator.Play(ShootAnimation);

        //RaycastHit hit;
        //if (Physics.Raycast(_rayPoint.Value.position, _rayPoint. Value.forward, out hit))
        //{
        //    if (hit.collider.TryGetComponent(out Bone bone))
        //    {
        //        bone.TakeDamage(_damage);
        //    }
        //}
    }
}
