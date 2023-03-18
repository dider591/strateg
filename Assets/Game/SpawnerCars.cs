using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCars : Spawner
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Car>(out Car car))
        {
            if (TargetPoint != null)
            {
                car.SetTargetPoint(TargetPoint);
            }
        }
    }

    public override void FindTargetPoint()
    {
        TargetPoint = FindObjectOfType<SoldierTargetPoint>().transform;
        //var points = FindObjectsOfType<CarTargetPoint>();
        //float distance = Vector3.Distance(transform.position, points[0].transform.position);

        //for (int i = 1; i < points.Length; i++)
        //{
        //    if (Vector3.Distance(transform.position, points[i].transform.position) < distance)
        //    {
        //        distance = Vector3.Distance(transform.position, points[i].transform.position);
        //        _currentTransform = points[i].transform;
        //    }
        //}

        //TargetPoint = _currentTransform;
    }
}
