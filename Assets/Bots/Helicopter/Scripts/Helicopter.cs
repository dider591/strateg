using UnityEngine.Events;
using UnityEngine;

public class Helicopter : Unit, ITakeDamage, IHealing, IDeath
{
    //[SerializeField] private Helicopter _helicopter;
    //[SerializeField] private Target _helicopterRagdoll;
    [SerializeField] private HelicopterRagdoll _helicopterRagdoll;
    [SerializeField] private ParticleSystem _smokeAndFire;
    //[SerializeField] private float _health;

    public UnityAction Crashed;
    public UnityAction<float> HealthChanged;
    public UnityAction GameOver;
    public UnityAction Healed;

    private int _maxHealth = 100;
    private int _minHealth = 0;

    //private void Awake()
    //{
    //    _helicopter.enabled = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketTerrorist>(out RocketTerrorist rocketTerrorist))
        {
            _smokeAndFire.Play();
        }
        if (other.TryGetComponent<Graund>(out Graund graund))
        {
            //_helicopter.gameObject.SetActive(false);
            //_helicopterRagdoll.gameObject.SetActive(true);
            Instantiate(_helicopterRagdoll, transform.position, transform.rotation);
            Crashed?.Invoke();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Death();
        }
    }

    public void Healing(int healing)
    {
        _health += healing;
        HealthChanged?.Invoke(_health);

        if (_health >= _maxHealth)
        {
            Healed?.Invoke();
            _health = _maxHealth;
        }
    }

    public void Death()
    {
        GameOver?.Invoke();
    }
}
