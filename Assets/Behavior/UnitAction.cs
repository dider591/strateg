using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Unit), typeof(Animator), typeof(NavMeshAgent))]
public class UnitAction : Action
{
    protected Unit _unit;
    protected Animator _animator;
    protected NavMeshAgent _agent;

    public override void OnAwake()
    {
        _unit = GetComponent<Unit>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
}
