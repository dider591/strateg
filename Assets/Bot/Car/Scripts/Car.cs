using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Car : Unit, ITakeDamage, ISetTargetPoint
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private Soldier _soldierShooter;

    protected bool _isInit;
    protected bool _isDeath;

    private int _force = 2000;

    public void SetTargetPoint(Vector3 point)
    {
        TargetPoint = point;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (isHealthViewer)
        {
            _healthViewer.SetSizeHealth(CurrentHealth);
        }

        if (Health <= 0)
        {
            Death();
        }
    }

    public override void Death()
    {
        if (_isDeath == false)
        {
            _isDeath = true;
            Rigidbody.AddForce(Vector3.up * _force);
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            Ragdoll.Disable();

            if (_soldierShooter != null)
            {
                _soldierShooter.gameObject.SetActive(false);
            }
        }
    }

    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, SearchRadius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<Unit>(out Unit targetUnit))
            {
                if (targetUnit.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA) && targetUnit.CurrentHealth > 0)
                {
                    Target = targetUnit;
                }
            }
        }
    }
}
