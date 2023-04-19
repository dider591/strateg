using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTargetPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Spawner>(out Spawner spawner))
        {
            Debug.Log("CarTargetPoint");
            spawner.SetReady(true);
        }
    }
}
