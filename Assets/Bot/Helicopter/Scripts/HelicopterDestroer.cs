using UnityEngine;

public class HelicopterDestroer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Car>(out Car car))
        {
            Debug.Log(car.name);
            Destroy(car.gameObject);
        }
    }
}
