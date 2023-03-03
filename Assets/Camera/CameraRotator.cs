using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _wayPoints;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("CameraMove");
    }

    private void Update()
    {
        if (transform.position == _wayPoints)
        {
            _animator.enabled = false;
            MoweCircle();
        }
    }

    private void MoweCircle()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, -_speed, 0) * Time.deltaTime);
    }
}
