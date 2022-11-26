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

    private float mouseX;
    private float mouseY;
    private bool _isZoom;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _camera.fieldOfView = _maxValue;
            _isZoom = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _camera.fieldOfView = _minValue;
            _isZoom = true;
        }

        if (_isZoom == true)
        {
            Look();
        }
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
}
