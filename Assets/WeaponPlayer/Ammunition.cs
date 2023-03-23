using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _forse;
    [SerializeField] private float _modifier;
    [SerializeField] private Explosion _explosion;

    private bool isExplosion = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isExplosion == false)
        {
            isExplosion = true;
            Instantiate(_explosion, transform.position, Quaternion.identity);
            OnExplosion();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }

    private void OnExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_forse, transform.position, _radius, _modifier, ForceMode.Force);

                if (rigidbody.TryGetComponent<Bone>(out Bone bone))
                {
                    bone.TakeDamage(_damage);
                }
                if (rigidbody.TryGetComponent<ITakeDamage>(out ITakeDamage iTakeDamage))
                {
                    iTakeDamage.TakeDamage(_damage);
                }

            }           
        }
    }
}
