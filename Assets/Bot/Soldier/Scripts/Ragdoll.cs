using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodys;
    [SerializeField] private Material _regdollMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _timeDestroy;

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
        foreach (var rigidbody in _rigidbodys)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void Disable()
    {
        foreach (var rigidbody in _rigidbodys)
        {
            rigidbody.isKinematic = false;
        }

        _animator.enabled = false;
        _agent.enabled = false;
        _behaviorDesigner.enabled = false;
        _renderer.material = _regdollMaterial;
        Destroy(gameObject, _timeDestroy);
    }
}
