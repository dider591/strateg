using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _wayPointsOne;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position == _wayPointsOne)
        {
            _animator.enabled = false;
            MoweCircle();
        }
    }

    private void MoweCircle()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, _speed, 0) * Time.deltaTime);
    }
}
