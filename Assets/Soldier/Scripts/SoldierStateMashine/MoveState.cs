using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private int Run = Animator.StringToHash("Run");
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Rotate();
        _animator.Play(Run);
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.LookAt(Target.transform.position);
    }
}
