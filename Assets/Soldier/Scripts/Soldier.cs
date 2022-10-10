using UnityEngine;
using UnityEngine.Events;

public class Soldier : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Soldier _target;

    public Soldier Target => _target;

    public event UnityAction Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Dying?.Invoke();
        }
    }
}
