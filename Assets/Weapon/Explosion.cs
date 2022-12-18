using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _forse;
    [SerializeField] private float _modifier;

    private void Start()
    {
        OnExplosion();
    }

    private void OnExplosion()
    {
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

        Destroy(gameObject, 1f);
    }
}
