using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMower : MonoBehaviour
{
    [SerializeField] private Transform _transformFrontLeft;
    [SerializeField] private Transform _transformFrontRight;
    [SerializeField] private Transform _transformBackLeftOne;
    [SerializeField] private Transform _transformBackLeftTwo;
    [SerializeField] private Transform _transformBackRightOne;
    [SerializeField] private Transform _transformBackRightTwo;

    [SerializeField] private WheelCollider _colliderFrontLeft;
    [SerializeField] private WheelCollider _colliderFrontRight;
    [SerializeField] private WheelCollider _colliderBackLeftOne;
    [SerializeField] private WheelCollider _colliderBackLeftTwo;
    [SerializeField] private WheelCollider _colliderBackRightOne;
    [SerializeField] private WheelCollider _colliderBackRightTwo;

    [SerializeField] private float _force;
    [SerializeField] private float _maxAngle;

    private void FixedUpdate()
    {
        _colliderFrontLeft.motorTorque = Input.GetAxis("Vertical") * _force;
        _colliderFrontRight.motorTorque = Input.GetAxis("Vertical") * _force;

        if (Input.GetKey(KeyCode.Space))
        {
            _colliderBackLeftOne.brakeTorque = 3000f;
            _colliderBackLeftTwo.brakeTorque = 3000f;
            _colliderBackRightOne.brakeTorque = 3000f;
            _colliderBackRightTwo.brakeTorque = 3000f;
        }
        else
        {
            _colliderBackLeftOne.brakeTorque = 0f;
            _colliderBackLeftTwo.brakeTorque = 0f;
            _colliderBackRightOne.brakeTorque = 0f;
            _colliderBackRightTwo.brakeTorque = 0f;
        }

        _colliderFrontLeft.steerAngle = _maxAngle * Input.GetAxis("Horizontal");
        _colliderFrontRight.steerAngle = _maxAngle * Input.GetAxis("Horizontal");

        RotateWheel(_colliderFrontLeft, _transformFrontLeft);
        RotateWheel(_colliderFrontRight, _transformFrontRight);
        RotateWheel(_colliderBackLeftOne, _transformBackLeftOne);
        RotateWheel(_colliderBackLeftTwo, _transformBackLeftTwo);
        RotateWheel(_colliderBackRightOne, _transformBackRightOne);
        RotateWheel(_colliderBackRightTwo, _transformBackRightTwo);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }
}
