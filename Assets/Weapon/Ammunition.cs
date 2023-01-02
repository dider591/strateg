using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _forse;
    [SerializeField] private float _modifier;
    [SerializeField] private Explosion _explosion;

    private bool isExplosion = false;

    private Soldier _soldier;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 position = collision.contacts[0].point;
        Quaternion rotaton = Quaternion.LookRotation(collision.contacts[0].normal);

        if (isExplosion == false)
        {
            isExplosion = true;
            Instantiate(_explosion, position, rotaton);
            OnExplosion();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
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

                if (rigidbody.TryGetComponent<Bone>(out Bone bone))
                {
                    bone.TakeDamage(_damage);
                }
            }
        }
    }
}
