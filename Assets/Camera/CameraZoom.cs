using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;
    [SerializeField] private float sensitivity;
    [SerializeField] private float _cameraOffsetLimit;

    private float _distance;
    private float _currentZoom;

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            ZoomDesktop();
        }
        if (Input.touchCount == 2)
        {
            ZoomMobile();
        }
        else if (_distance != 0)
        {
            _distance = 0;
        }

        ControlPosition();
    }

    private void ZoomMobile()
    {
        Vector2 fingerOne = Input.GetTouch(0).position;
        Vector2 fingerTwo = Input.GetTouch(1).position;

        if (_distance == 0) _distance = Vector2.Distance(fingerOne, fingerTwo);

        float delta = Vector2.Distance(fingerOne, fingerTwo) - _distance;
        Camera.main.fieldOfView -= delta * Time.deltaTime;
        _distance = Vector2.Distance(fingerOne, fingerTwo);

        if (Camera.main.fieldOfView < _minZoom)
        {
            Camera.main.fieldOfView = _minZoom;
        }
        if (Camera.main.fieldOfView > _maxZoom)
        {
            Camera.main.fieldOfView = _maxZoom;
        }
    }

    private void ZoomDesktop()
    {
        _currentZoom = Camera.main.fieldOfView;
        _currentZoom -= Input.mouseScrollDelta.y * sensitivity;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
        Camera.main.fieldOfView = _currentZoom;
    }

    private void ControlPosition()
    {
        if (transform.localPosition.x < -_cameraOffsetLimit)
        {
            transform.localPosition = new Vector3(-_cameraOffsetLimit, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x > _cameraOffsetLimit)
        {
            transform.localPosition = new Vector3(_cameraOffsetLimit, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y < -_cameraOffsetLimit)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -_cameraOffsetLimit, transform.localPosition.z);
        }
        if (transform.localPosition.y > _cameraOffsetLimit)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, _cameraOffsetLimit, transform.localPosition.z);
        }
    }
}

