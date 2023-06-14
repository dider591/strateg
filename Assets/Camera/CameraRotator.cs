using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _wayPointsOne;

    private Animator _animator;
    private Transform _transform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (_transform.position == _wayPointsOne)
        {
            _animator.enabled = false;
            MoweCircle();
        }
    }

    private void MoweCircle()
    {
        _transform.rotation *= Quaternion.Euler(new Vector3(0, _speed, 0) * Time.deltaTime);
    }
}
