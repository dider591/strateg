using UnityEngine;
using UnityEngine.UI;

public class Destructor : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private int _health;

    public int Health => _health;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destruct();
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
