using UnityEngine;

public class CameraMower : MonoBehaviour
{
    [SerializeField]private float _speed;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, -_speed, 0) * Time.deltaTime);
    }
}
