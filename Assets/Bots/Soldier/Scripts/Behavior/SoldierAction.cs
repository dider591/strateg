using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAction : Action
{
    protected Unit Unit;
    protected Animator Animator;
    protected NavMeshAgent Agent;

    public override void OnAwake()
    {
        Unit = GetComponent<Unit>();
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }
}
