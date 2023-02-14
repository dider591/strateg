using UnityEngine.Events;
using UnityEngine;

public class HelicopterMain : MonoBehaviour
{
    [SerializeField] private Helicopter _helicopter;
    [SerializeField] private Target _helicopterRagdoll;
    [SerializeField] private ParticleSystem _smokeAndFire;
    [SerializeField] private float _health;

    public UnityAction<Vector3> CrashedPoint;
    public UnityAction<float> HealthChanged;
    public UnityAction GameOver;

    private float _maxHealth = 1f;
    private float _minHealth = 0f;

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

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            OnGameOver();
        }
    }

    public void Healing(float healing)
    {
        _health += healing;
        HealthChanged?.Invoke(_health);

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void OnGameOver()
    {
        GameOver?.Invoke();
    }
}
