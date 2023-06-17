using UnityEngine;

public class Wall : MonoBehaviour, ITakeDamage
{
    private Building _destructor;
    private float _destroiTime = 5f;

    private void Awake()
    {
        _destructor = GetComponentInParent<Building>();
    }

    public void TakeDamage(int damage)
    {
        _destructor.TakeDamage(damage);

        if (_destructor.CurrentHealth <= 0)
        {
            Destroy(gameObject, _destroiTime);
        }
    }
}
