using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackState : SoldierAction
{
    //[SerializeField] private SharedTransform _rayPoint;
    //[SerializeField] private int _damage;
    //[SerializeField] private ParticleSystem _bulletEffect;
    [SerializeField] private AudioSource _audioShoot;

    private int ShootAnimation = Animator.StringToHash("Shoot");

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
        //_bulletEffect.Play();
        _audioShoot.Play();
        _animator.Play(ShootAnimation);

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
