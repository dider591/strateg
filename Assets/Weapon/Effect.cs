using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Soldier soldier = other.GetComponent<Soldier>();

        if (soldier)
        {
            soldier.OnHit();
        }
    }
}
