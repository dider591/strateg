using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ITakeDamage
{
    private Destructor _destructor;
    private Collider _collider;
    private float _destroiTime = 5f;

    private void Awake()
    {
        _destructor = GetComponentInParent<Destructor>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (_destructor.Health <= 0)
        {
            Destroy(gameObject, _destroiTime);
        }
    }

    public void TakeDamage(int damage)
    {
        _destructor.TakeDamage(damage);

    }
}
