using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected int Reward;
    [SerializeField] protected float SearchRadius;

    protected Vector3 TargetPoint;
    protected Rigidbody ThisRigidbody;
    protected Unit Target;
    protected Ragdoll Ragdoll;

    public Vector3 CurrentTargetPoint => TargetPoint;
    public Unit CurrentTarget => Target;
    public int CurrentHealth => Health;

    private void Start()
    {
        ThisRigidbody = GetComponent<Rigidbody>();
        Ragdoll = GetComponent<Ragdoll>();
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

    //Сделать нормальный регдолл машинам
    //создать гит
    //обновить документ игры и посмотреть как сделали документ другие
}
