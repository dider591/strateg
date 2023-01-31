using UnityEngine.Events;
using UnityEngine;

public class HelicopterMain : MonoBehaviour
{
    [SerializeField] private Helicopter _helicopter;
    [SerializeField] private Target _helicopterRagdoll;
    [SerializeField] private ParticleSystem _smokeAndFire;

    //private bool _isAdded = false;

    public event UnityAction<Vector3> CrashedPoint;

    private void Awake()
    {
        _helicopter.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketTerrorist>(out RocketTerrorist rocketTerrorist))
        {
            _smokeAndFire.Play();
        }
        if (other.TryGetComponent<Graund>(out Graund graund))
        {
            _helicopter.gameObject.SetActive(false);
            _helicopterRagdoll.gameObject.SetActive(true);
            CrashedPoint?.Invoke(transform.position);
        }
    }
}
