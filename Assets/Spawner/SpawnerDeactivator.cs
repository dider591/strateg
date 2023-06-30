using UnityEngine;

public class SpawnerDeactivator : MonoBehaviour
{
    private Car _car;
    private Spawner _spawner;

    private void OnEnable()
    {
        _car = GetComponentInParent<Car>();
        _spawner = GetComponent<Spawner>();
        _car.Dead += OnCarDead;
    }

    private void OnDisable()
    {
        _car.Dead -= OnCarDead;
    }

    private void OnCarDead()
    {
        _spawner.enabled = false;
    }
}
