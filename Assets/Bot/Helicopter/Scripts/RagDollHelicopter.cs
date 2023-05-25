using UnityEngine.Events;
using UnityEngine;

public class RagDollHelicopter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _smokeAndFire;
    [SerializeField] private GameObject _helicopterRagdoll;
    [SerializeField] private GameObject _helicopterModel;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _helicopterModel.SetActive(true);
        _helicopterRagdoll.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketTerrorist>(out RocketTerrorist rocketTerrorist))
        {
            Crash();
        }
        if (other.TryGetComponent<PointCrashed>(out PointCrashed pointCrashed))
        {
            _helicopterModel.SetActive(false);
            _helicopterRagdoll.SetActive(true);
        }
    }

    public void Crash()
    {
        _smokeAndFire.Play();
    }
}
