using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Effect _shoootEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 position = collision.contacts[0].point;
        Quaternion rotaton = Quaternion.LookRotation(collision.contacts[0].normal);

        Instantiate(_shoootEffect, position, rotaton);
        Destroy(gameObject);
    }


    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

}
