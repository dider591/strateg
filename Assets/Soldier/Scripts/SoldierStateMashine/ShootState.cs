using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShootState : State
{
    private Animator _animator;
    private int Shoot = Animator.StringToHash("Shoot");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.Play(Shoot);
    }
}
