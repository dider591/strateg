using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRay : MonoBehaviour
{
    private RaycastHit hit;

    public Vector3 Point => hit.point;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        Physics.Raycast(ray, out hit);
    }
}
