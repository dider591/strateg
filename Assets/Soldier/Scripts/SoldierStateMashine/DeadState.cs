using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeadState : State
{
    [SerializeField] private GameObject _ragdooll;

    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        Died();
    }

    private void Died()
    {
        Instantiate(_ragdooll, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
