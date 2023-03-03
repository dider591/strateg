using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Bounds")]
    [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound;
    [SerializeField] private float _upBound;
    [SerializeField] private float _downBound;

    [Header("JoystickSettings")]
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ControlPosition();
        Move(GetDirection());
    }

    public void Move(Vector3 direction)
    {
        _transform.localPosition += direction * _moveSpeed * Time.deltaTime;
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = new Vector3(_joystick.Vertical, 0, -_joystick.Horizontal);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction.z = 1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction.z = -1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction.x = 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction.x = -1;

        return direction;
    }

    private void ControlPosition()
    {
        if (_transform.localPosition.x < -_leftBound)
        {
            _transform.localPosition = new Vector3(-_leftBound, _transform.localPosition.y, _transform.localPosition.z);
        }
        if (_transform.localPosition.x > _rightBound)
        {
            _transform.localPosition = new Vector3(_rightBound, _transform.localPosition.y, _transform.localPosition.z);
        }
        if (_transform.localPosition.z < -_downBound)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, -_downBound);
        }
        if (_transform.localPosition.z > _upBound)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, _upBound);
        }
    }
}
