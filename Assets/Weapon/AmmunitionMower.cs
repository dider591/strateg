using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionMower : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}
