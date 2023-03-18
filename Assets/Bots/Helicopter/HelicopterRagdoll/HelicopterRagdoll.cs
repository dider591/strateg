using UnityEngine;

public class HelicopterRagdoll : MonoBehaviour
{
    [SerializeField] private ParticleSystem _boomEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Graund>(out Graund graund))
        {
            Instantiate(_boomEffect, transform.position, transform.rotation);
        }
    }
}
