using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;

    protected Vector3 _crashPoint;

    public Vector3 CrashPoint => _crashPoint;

    public int Health => _health;

    public void Init(Vector3 crashpoint)
    {
        _crashPoint = crashpoint;
    }
}
