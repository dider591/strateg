using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private int _health;

    public UnityAction Dead;
    public UnityAction ChangeHealth;
    public int Health => _health;

    private bool isDead;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke();

        if (_health <= 0)
        {
            if (isDead != true)
            {
                Dead?.Invoke();
                Destruct();
                isDead = true;
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
