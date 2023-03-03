using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Material _regdollMaterial;
    [SerializeField] private Renderer _renderer;

    private Animator _animator;
    private NavMeshAgent _agent;
    private BehaviorTree _behaviorDesigner;

    private void Awake()
    {
        Enable();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _behaviorDesigner = GetComponent<BehaviorTree>();
    }

    private void Enable()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void Disable()
    {
        foreach (var rigidbodi in _rigidbodies)
        {
            rigidbodi.isKinematic = false;
        }

        _animator.enabled = false;
        _agent.enabled = false;
        _behaviorDesigner.enabled = false;
        _renderer.material = _regdollMaterial;
        Destroy(gameObject, 10f);
    }
}
