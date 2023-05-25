using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Car : Unit, ITakeDamage, ISetTargetPoint
{
    [SerializeField] private Explosion _explosionEffect;
    [SerializeField] private WeaponCar _weaponCar;

    protected bool _isInit;
    protected bool _isDeath;

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
            ThisRigidbody.AddForce(2000f, 0, 0);
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            Ragdoll.Disable();

            if (_weaponCar != null)
            {
                _weaponCar.gameObject.SetActive(false);
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
