using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodys;
    [SerializeField] private Material _regdollMaterial;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private float _timeDestroy;
    [SerializeField] private float _drag = 0f;

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
            rigidbody.drag = _drag;
        }

        _animator.enabled = false;
        _agent.enabled = false;

        if (_behaviorDesigner != null)
        {
            _behaviorDesigner.enabled = false;
        }

        foreach (var renderer in _renderers)
        {
            Material[] materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = _regdollMaterial;
            }

            renderer.materials = materials;
        }

        Destroy(gameObject, _timeDestroy);
    }
}
