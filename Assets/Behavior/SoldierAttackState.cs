using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SoldierAttackState : UnitAction
{
    [SerializeField] private Ammunition _ammunition;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _range;
    [SerializeField] private AudioSource _shootAudio;
    [SerializeField] private ParticleSystem _hitEffect;

    private int ShootAnimation = Animator.StringToHash("Shoot");
    private SharedGameObject _storeResult;

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

        //if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        //{

        //}

        //Ammunition ammunition = _objectsPooler.GetPooledObject();

        //if (ammunition != null)
        //{
        //    ammunition.gameObject.SetActive(true);
        //    ammunition.transform.position = _shootPoint.position;
        //    ammunition.transform.rotation = _shootPoint.rotation;
        //}

        GameObject.Instantiate(_ammunition, _shootPoint.transform.position, _shootPoint.transform.rotation);

        _animator.Play(ShootAnimation);
    }
}
