using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private int _health;
    [SerializeField] private HealthViewer _healthViewer;


    public UnityAction Dead;
    public int CurrentHealth => _health;
    private bool _isHealthViewer => _healthViewer != null;

    private bool _isDead;

    private void Awake()
    {
        if (_isHealthViewer)
        {
            _healthViewer.SetSizeHealth(_health);
        }
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_isHealthViewer)
        {
            _healthViewer.HealthChange(_health);
        }

        if (_health <= 0)
        {
            if (_isDead != true)
            {
                Dead?.Invoke();
                Destruct();
                _isDead = true;
            }
        }
    }

    private void Destruct()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            if (rigidbody.TryGetComponent<Wall>(out Wall wall))
            {
                rigidbody.isKinematic = false;
            }
        }
    }
}
