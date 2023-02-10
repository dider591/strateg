using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class CameraMower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _wayPoints;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("CameraMove");
    }

    private void Update()
    {
        if (transform.position == _wayPoints[0])
        {
            MoweCircle();
        }
    }

    private void MoweCircle()
    {
            Debug.Log("CameraMower");
        transform.rotation *= Quaternion.Euler(new Vector3(0, -_speed, 0) * Time.deltaTime);
    }
}
