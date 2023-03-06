using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public abstract class Car : Unit
{
    [SerializeField] private RagdollCar _ragdollCar;

    protected Transform _targetPoint;
    protected Rigidbody _rigidbody;
    protected NavMeshAgent _agent;
    protected Vector3 _crashPoint;
    protected bool _isInit;
    private float _radius = 1f;
    private float _forse = 600f;
    private float _modifier = 2;
    private int _damage = 10;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isInit)
        {
            Move();
        }
    }

    public void Init(Vector3 crashpoint, Transform targetPoint)
    {
        _crashPoint = crashpoint;
        _targetPoint = targetPoint;
        _isInit = true;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Died();
        }
    }
    public void Died()
    {
        Explosion();
        Instantiate(_ragdollCar, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explosion()
    {
        _rigidbody.AddForce(new Vector3(0, 10, 0));
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_forse, transform.position, _radius, _modifier, ForceMode.Acceleration);

                if (rigidbody.TryGetComponent<Soldier>(out Soldier soldier))
                {
                    soldier.TakeDamage(_damage);
                }
            }
        }
    }

    private void Move()
    {
        _agent.SetDestination(_targetPoint.position);
    }
}
