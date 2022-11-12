using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class ReturnPositionState : State
{
    private int Walk = Animator.StringToHash("Walk");
    private Animator _animator;
    private NavMeshAgent _agent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        transform.LookAt(StartPoint);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        _animator.Play(Walk);
        _agent.SetDestination(StartPoint);
    }
}
