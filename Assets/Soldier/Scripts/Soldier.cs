using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private float _health;
    //[SerializeField] private OverviewZone _overviewZone;
    //[SerializeField] private SoldierStateMashine _stateMashine;
    [SerializeField] private Rigidbody[] _allBones;
    //[SerializeField] private Ragdoll _ragdoll;


    private Rigidbody _rigidbody;
    private Soldier _target;
    private Vector3 _startPoint;
    private Animator _animator;
    public Soldier Target => _target;
    public Vector3 StartPoint => _startPoint;

    public event UnityAction Dying;

    private void Awake()
    {
        foreach (var bones in _allBones)
        {
            bones.isKinematic = true;
        }
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _startPoint = transform.position;
        //_overviewZone.SawEnemy += OnSawEnemy;
    }

    //private void Update()
    //{
    //    if (Target != null)
    //    {
    //        _stateMashine.enabled = true;
    //    }
    //    if (Target == null && (transform.position.x == StartPoint.x && transform.position.z == StartPoint.z))
    //    {
    //        _stateMashine.enabled = false;
    //    }
    //}

    //private void OnDisable()
    //{
    //    _overviewZone.SawEnemy -= OnSawEnemy;
    //}

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            OnDied();
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

    public void OnDied()
    {
       // _rigidbody.AddForce(5f, 0, 0);

        foreach (var bones in _allBones)
        {
            bones.isKinematic = false;
        }
    }
}
