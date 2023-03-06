using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPickup : Car
{
    private void OnTriggerEnter(Collider other)
    {
        if (_crashPoint != null)
        {
            if (other.TryGetComponent<CarTargetPoint>(out CarTargetPoint unloadingPoint))
            {
                _isInit = false;
                _agent.enabled = false;
            }
        }
    }
}
