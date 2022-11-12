using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;


    private void Update()
    {
        transform.LookAt(_targetPoint.transform.position);
    }
}
