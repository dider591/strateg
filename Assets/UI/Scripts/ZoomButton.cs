using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ZoomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected Camera _camera;

    protected CameraZoom _cameraZoom;
    private Coroutine _zoom;

    private void Awake()
    {
        _cameraZoom = _camera.GetComponent<CameraZoom>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_zoom != null)
        {
            StopCoroutine(_zoom);
            _zoom = StartCoroutine(Zoom());
        }
        else
        {
            _zoom = StartCoroutine(Zoom());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_zoom != null)
            StopCoroutine(_zoom);
    }

    public virtual IEnumerator Zoom()
    {
        while (true)
        {
            _cameraZoom.ZoomIn();
            yield return null;
        }
    }
}