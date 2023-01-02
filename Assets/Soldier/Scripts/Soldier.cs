using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ragdoll))]

public abstract class Soldier : MonoBehaviour
{
    [SerializeField] protected float _radius;
    [SerializeField] private HelicopterRagdoll _helicopterRagdoll;
    [SerializeField] private float _health;
    [SerializeField] private Bone[] _bones;

    protected Soldier _target;

    private Ragdoll _ragdoll;
    private Vector3 _startPoint;
    private Collider _collider;


    public Soldier Target => _target;
    public Vector3 StartPoint => _startPoint;

    public event UnityAction Dying;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
        _ragdoll = GetComponent<Ragdoll>();

        foreach (var bone in _bones)
        {
            bone.TakingDamage += TakeDamage;
        }
    }

    public void OnSawEnemy(Soldier target)
    {
        if (Target == null)
        {
            _target = target;
        }
    }

    private void OnDisable()
    {
        foreach (var bone in _bones)
        {
            bone.TakingDamage -= TakeDamage;
        }
    }

    private void Update()
    {
        if (_target == null)
        {
            SearchTarget();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke();
            OnDied();
        }
    }

    public void OnDied()
    {
        _ragdoll.ActivateRagdoll();
        Destroy(gameObject, 10f);
    }

    public abstract void SearchTarget();


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
