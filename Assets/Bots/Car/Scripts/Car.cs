using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Car : Unit, ITakeDamage, IDeath
{
    protected Rigidbody _rigidbody;
    protected NavMeshAgent _agent;
    private float _forse = 600f;
    private float _modifier = 2;


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<CarTargetPoint>(out CarTargetPoint unloadingPoint))
    //    {
    //        _agent.enabled = false;
    //    }
    //}
    //private void Awake()
    //{
    //    SetTargetPoint();
    //}

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();      
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (!_isDead)
        {
            Explosion();
            FindObjectOfType<Player>().AddManey(_reward);
            _ragdoll.Disable();
        }
        _isDead = true;
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
}
