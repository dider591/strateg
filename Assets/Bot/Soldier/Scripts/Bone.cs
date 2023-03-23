using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField] private Soldier _soldier;

    private void Start()
    {
        _soldier = GetComponentInParent<Soldier>();
    }

    public void TakeDamage(int damage)
    {
        _soldier.TakeDamage(damage);
    }
}
