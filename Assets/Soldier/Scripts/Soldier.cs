using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private OverviewZone _overviewZone;
    [SerializeField] private SoldierStateMashine _stateMashine;

    private Soldier _target;
    private Vector3 _startPoint;
    private Rigidbody _rigidbody;
    public Soldier Target => _target;
    public Vector3 StartPoint => _startPoint;

    public event UnityAction Dying;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPoint = transform.position;
        _overviewZone.SawEnemy += OnSawEnemy;
    }

    private void Update()
    {
        if (Target != null)
        {
            _stateMashine.enabled = true;
        }
        if (Target == null && (transform.position.x == StartPoint.x && transform.position.z == StartPoint.z))
        {
            _stateMashine.enabled = false;
        }
    }

    private void OnDisable()
    {
        _overviewZone.SawEnemy -= OnSawEnemy;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Dying?.Invoke();
        }
    }

    public void OnSawEnemy(Soldier target)
    {
        if (Target == null)
        {
            _target = target;
        }
    }

    public void OnHit()
    {
        _rigidbody.AddForce(Vector3.up * 1600f);
        _rigidbody.AddTorque(800f, 0f, 0f);
    }
}
