using UnityEngine.Events;
using UnityEngine;

public class FallenHelicopter : Unit, ITakeDamage
{
    [SerializeField] private ParticleSystem _smokeAndFire;
    [SerializeField] private GameObject _helicopterRagdoll;
    [SerializeField] private GameObject _helicopterModel;


    private float _health;
    private Rigidbody _rigidbody;

    public UnityAction Crashed;
    public UnityAction<float> HealthChanged;
    public UnityAction Healed;
    public UnityAction GameOver;

    private float _maxHealth = 1f;
    private float _minHealth = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = _maxHealth;
        _helicopterModel.SetActive(true);
        _helicopterRagdoll.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Graund>(out Graund graund))
        {
            Crashed?.Invoke();
            _helicopterModel.SetActive(false);
            _helicopterRagdoll.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= (float)damage / 1000f;
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Death();
        }
    }

    public void Healing(int healing)
    {
        _health += (float)healing / 1000f;
        HealthChanged?.Invoke(_health);

        if (_health >= _maxHealth)
        {
            Healed?.Invoke();
            _health = _maxHealth;
        }
    }

    public void Crash()
    {
        _smokeAndFire.Play();
        _rigidbody.isKinematic = false;
    }

    public override void Death()
    {
        GameOver?.Invoke();
    }

    public override void SearchTarget()
    {       
    }
}
