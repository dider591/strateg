using UnityEngine;
using DG.Tweening;

public class CameraMower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _wayPoints;
    [SerializeField] private float _duration;

    private bool isToPoint = false;

    private void Update()
    {
        MoweToPoint();

        if (isToPoint)
        {
            MoweCircle();
        }
    }

    private void MoweToPoint()
    {
        transform.DOPath(_wayPoints, _duration, PathType.CatmullRom);

        if (transform.position == _wayPoints[_wayPoints.Length - 1])
        {
            isToPoint = true;
        }
    }

    private void MoweCircle()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, -_speed, 0) * Time.deltaTime);
    }
}
