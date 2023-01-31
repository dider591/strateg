using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAction : Action
{
    protected Soldier _soldier;
    protected Animator _animator;
    protected NavMeshAgent _agent;

    public override void OnAwake()
    {
        _soldier = GetComponent<Soldier>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
}
