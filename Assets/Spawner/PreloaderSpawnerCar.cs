using UnityEngine;

public class PreloaderSpawnerCar : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Car _car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Car>(out Car car))
        {
            _car = car;
            _car.Dead += OnCarDead;
        }
    }

    private void OnCarDead()
    {
        _spawner.SetReady(true);
        _car.Dead -= OnCarDead;
    }
}
