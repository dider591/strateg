using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private float _timeDestroi = 20f;

    private void Start()
    {
        Destroy(gameObject, _timeDestroi);
    }
}
