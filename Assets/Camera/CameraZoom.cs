using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _cameraOffsetLimit;

    private const string _mouseWheel = "Mouse ScrollWheel";
    private Camera _camera;
    private float _wheelSpeedMultiplier = 6f;

    public float MaxZoom => _maxZoom;
    public float MinZoom => _minZoom;

    private void Start()
    {
        _camera = Camera.main;
        _camera.fieldOfView = _maxZoom;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
            ZoomIn();

        if (Input.GetKey(KeyCode.Q))
            ZoomOut();

        if (Input.GetAxis(_mouseWheel) > 0)
            ZoomIn(_wheelSpeedMultiplier);

        if (Input.GetAxis(_mouseWheel) < 0)
            ZoomOut(_wheelSpeedMultiplier);
    }


    public void ZoomIn(float multiplier = 3f)
    {
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _minZoom, Time.unscaledDeltaTime * _zoomSpeed * multiplier);
    }

    public void ZoomOut(float multiplier = 3f)
    {
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _maxZoom, Time.unscaledDeltaTime * _zoomSpeed * multiplier);
    }
}

