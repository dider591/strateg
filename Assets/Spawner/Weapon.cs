using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int CountBullet;
    [SerializeField] protected Ammunition Bullet;

    protected Vector3 _shootPoint;

    private void Update()
    {
        LookAim(_shootPoint);
    }

    protected void LookAim(Vector3 point)
    {
        _shootPoint = point;
        transform.LookAt(point);
    }

    public abstract void Shoot(Vector3 shootPoint);
}
