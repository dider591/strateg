using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPoint;

    private void Start()
    {
        transform.DOMove(_targetPoint, 5f);
    }

    private void Update()
    {
        if (transform.position == _targetPoint)
        {
            Debug.Log("instantiate");
        }
    }
}
