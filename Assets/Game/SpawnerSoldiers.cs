using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSoldiers : Spawner
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Soldier>(out Soldier soldier))
        {
            if (TargetPoint != null)
            {
                soldier.SetTargetPoint(TargetPoint);
            }
        }
    }

    public override void FindTargetPoint()
    {
        TargetPoint = FindObjectOfType<SoldierTargetPoint>().transform;
        //var points = FindObjectsOfType<SoldierTargetPoint>();
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
