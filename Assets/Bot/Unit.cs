using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected int Reward;
    [SerializeField] protected float SearchRadius;
    [SerializeField] protected HealthViewer _healthViewer;

    protected Vector3 TargetPoint;
    protected Rigidbody Rigidbody;
    protected Unit Target;
    protected Ragdoll Ragdoll;
    protected Helicopter MainTarget;

    protected bool isHealthViewer => _healthViewer != null;

    public UnityAction ChangeHealth;
    public Vector3 CurrentTargetPoint => TargetPoint;
    public Unit CurrentTarget => Target;
    public int CurrentHealth => Health;
    public Helicopter CurrentMainTarget => MainTarget;

    private void Start()
    {
        if (isHealthViewer)
        {
            _healthViewer.SetSizeHealth(CurrentHealth);
        }

        Rigidbody = GetComponent<Rigidbody>();
        Ragdoll = GetComponent<Ragdoll>();
        MainTarget = FindObjectOfType<Helicopter>();      
    }

    private void Update()
    {
        if (Target == null)
        {
            SearchTarget();
        }
        if (Target != null && Target.CurrentHealth <= 0)
        {
            Target = null;
            SearchTarget();
        }
    }

    public void Init(Vector3 point)
    {
        TargetPoint = point;
    }

    public abstract void Death();
    public abstract void SearchTarget();
}
