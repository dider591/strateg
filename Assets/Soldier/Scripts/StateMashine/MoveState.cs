using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class MoveState : State
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
        if (Target != null)
        {
            transform.LookAt(Target.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        _animator.Play(Walk);
        _agent.SetDestination(Target.transform.position);
    }
}
