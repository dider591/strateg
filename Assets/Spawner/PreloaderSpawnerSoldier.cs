using UnityEngine;

public class PreloaderSpawnerSoldier : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Car _car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Car>(out Car car))
        {
            _car = car;
            _car.Dead += OnCarDead;
            _spawner.SetReady(true);
        }
    }

    private void OnCarDead()
    {
        _car.Dead -= OnCarDead;
    }
}
