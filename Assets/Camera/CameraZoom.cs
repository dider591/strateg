using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _minValue;
    [SerializeField] private float _cameraOffsetLimit;
    [SerializeField] private float _speed;
    [SerializeField] private Camera _camera;
    [SerializeField] private float sensitivity;

    private Vector2 f0start;
    private Vector2 f1start;

    private float mouseX;
    private float mouseY;
    private bool _isZoom;
    private Vector3 _touchStart;
    private float _currentDelta;

    private void Update()
    {
        if (Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }
        if (Input.touchCount == 2) Zoom();

        //if (Input.GetMouseButtonUp(0))
        //{
        //    _camera.fieldOfView = _maxValue;
        //    _isZoom = false;
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    _camera.fieldOfView = _minValue;
        //    _isZoom = true;
        //}

        //if (_isZoom == true)
        //{
        //    Look();
        //}
    }

    private void Look()
    {
        mouseX += Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(
            new Vector3(-Mathf.Clamp(mouseY, -_cameraOffsetLimit, _cameraOffsetLimit),
            Mathf.Clamp(mouseX, -_cameraOffsetLimit, _cameraOffsetLimit),
            transform.localRotation.z)
            );

        transform.localPosition = new Vector3(
            Mathf.Clamp(mouseX, -_cameraOffsetLimit, _cameraOffsetLimit),
            Mathf.Clamp(mouseY, -_cameraOffsetLimit, _cameraOffsetLimit),
            transform.localRotation.z
        );
    }

    private void Zoom()
    {
        if (f0start == Vector2.zero && f1start == Vector2.zero)
        {
            f0start = Input.GetTouch(0).position;
            f1start = Input.GetTouch(1).position;
        }

        Vector2 f0position = Input.GetTouch(0).position;
        Vector2 f1position = Input.GetTouch(1).position;

        float dir = Mathf.Sign(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position));
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position));
    }
}

