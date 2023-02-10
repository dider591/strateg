using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTripod : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.LookAt(_target);
    }
}
