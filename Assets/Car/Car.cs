using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private Transform _spawnSoldierPoint;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private int _countSoldier;
    [SerializeField] private int _health;
    [SerializeField] private float _stepSpawn;

    public float Health => _health;

    private Rigidbody _rigidbody;
    private Vector3 _crashPoint;
    private bool _isAllCreated;
    private float _radius = 1f;
    private float _forse = 600f;
    private float _modifier = 2;
    private int _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (_crashPoint != null)
        {
            if (other.TryGetComponent<Soldier>(out Soldier soldier))
            {
                soldier.SetCrashPoint(_crashPoint);
            }
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Move();
    }

    private void Update()
    {
        if (_isAllCreated == false && transform.position == _targetPoint)
        {
            _isAllCreated = true;
            StartCoroutine(InstantiateCars());
        }
    }

    public void SetCrashPoint(Vector3 crashpoint)
    {
        _crashPoint = crashpoint;
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
        Instantiate(_ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explosion()
    {
        _rigidbody.AddForce(new Vector3(0,10,0));
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

    private IEnumerator InstantiateCars()
    {
        if (transform.position == _targetPoint)
        {
            for (int i = 0; i < _countSoldier; i++)
            {
                Instantiate(_soldier, _spawnSoldierPoint.position, _spawnSoldierPoint.rotation);
            }
        }

        yield return new WaitForSeconds(_stepSpawn);
    }

    private void Move()
    {
        transform.DOMove(_targetPoint, 8f);
    }
}
