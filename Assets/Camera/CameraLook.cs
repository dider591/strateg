using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CameraLook : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private Transform _target;

    private float _delta = 0.01f;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            _target.localPosition += new Vector3(eventData.delta.x * _delta, 0, 0);
        }
        else
        {
            _target.localPosition += new Vector3(0, eventData.delta.y * _delta, 0);
        }
    }
}
