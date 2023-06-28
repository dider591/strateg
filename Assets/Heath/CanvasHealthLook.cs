using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHealthLook : MonoBehaviour
{
    private TargetHeathView _targetLookPoint;
    private Transform _transform;

    private void Start()
    {
        _targetLookPoint = FindObjectOfType<TargetHeathView>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.LookAt(_targetLookPoint.transform.position);
    }
}
