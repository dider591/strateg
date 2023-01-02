using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bone : MonoBehaviour
{
    public event UnityAction<int> TakingDamage;

    public void TakeDamage(int damage)
    {
        Debug.Log("takebone");
        TakingDamage?.Invoke(damage);
    }
}
