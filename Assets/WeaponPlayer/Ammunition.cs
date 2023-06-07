using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _forse;
    [SerializeField] private float _modifier;
    [SerializeField] private ParticleSystem _explosion;

    private bool _isExplosion = false;
    private Transform _transform;
    private float _timeLife = 3f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        Invoke(nameof(Disabled), _timeLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (_isExplosion == false)
            {
                _isExplosion = true;
                OnExplosion();         
            }

            Disabled();
        }
    }

    private void FixedUpdate()
    {
        _transform.position += _transform.forward * _speed * Time.deltaTime;
    }

    private void OnExplosion()
    {
        Instantiate(_explosion, _transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_forse, _transform.position, _radius, _modifier, ForceMode.Force);

                if (rigidbody.TryGetComponent<ITakeDamage>(out ITakeDamage iTakeDamage))
                {
                    iTakeDamage.TakeDamage(_damage);
                }
            }
        }
    }

    private void Disabled()
    {
        Destroy(gameObject);
    }
}
