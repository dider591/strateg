using System;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private SpawnRay _spawnRay;

    private void Update()
    {
        transform.LookAt(_spawnRay.Point);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_weapon, transform.position, transform.rotation);
        }
    }
}
