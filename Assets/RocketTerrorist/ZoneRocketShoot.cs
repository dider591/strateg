using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRocketShoot : MonoBehaviour
{
    [SerializeField] private RocketTerrorist _rocketTerrorist;
    [SerializeField] private Transform _spawnPoint;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Helicopter>(out Helicopter helicopter))
        {
            Instantiate(_rocketTerrorist, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
