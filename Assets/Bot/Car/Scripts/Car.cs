using UnityEngine;
using UnityEngine.Events;

public class Car : Unit, ITakeDamage, ISetTargetPoint
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _forse;
    [SerializeField] private float _modifier;

    protected bool _isInit;
    protected bool _isDeath;

    private int _force = 2000;
    private bool _isDead;

    public UnityAction Dead;

    public void SetTargetPoint(Vector3 point)
    {
        TargetPoint = point;
    }

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;

            if (isHealthViewer)
            {
                _healthViewer.HealthChange(Health);
            }

            if (Health <= 0)
            {
                if (_isDead != true)
                {
                    Dead?.Invoke();
                    Death();
                    _isDead = true;
                }
            }
        }
    }

    public override void Death()
    {
        if (_isDeath == false)
        {
            _isDeath = true;
            Rigidbody.AddForce(Vector3.up * _force);
            Instantiate(_explosionEffect, transform.position, transform.rotation);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (var collider in colliders)
            {
                Rigidbody rigidbody = collider.attachedRigidbody;

                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(_forse, transform.position, _radius, _modifier, ForceMode.Force);

                    if (rigidbody.TryGetComponent<ITakeDamage>(out ITakeDamage iTakeDamage))
                    {
                        iTakeDamage.TakeDamage(_damage);
                    }
                }
            }

            Ragdoll.Disable();
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
