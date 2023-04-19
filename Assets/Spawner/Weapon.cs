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
        AimRay();
        //transform.LookAt(_shootPoint);
        //LookAim(_shootPoint);
    }

    //protected void LookAim(/*Vector3 point*/)
    //{
    //    //_shootPoint = point;
    //    transform.LookAt(point);
    //}

    public abstract void Shoot(/*Vector3 shootPoint*/);
    //public void FindAim()
    //{
    //    _shootPoint = FindObjectOfType<Aim>().transform.position;
    //}

    private void AimRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
    }
}
