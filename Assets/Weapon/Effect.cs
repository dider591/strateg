using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("soldier");
        Soldier soldier = other.GetComponent<Soldier>();

        if (soldier)
        {
            Debug.Log("soldier");
            soldier.OnHit();
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

}
