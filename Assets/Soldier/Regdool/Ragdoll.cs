using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _randomForse;
    private Vector3 _randomTorque;
    private Vector3 _angleRandom;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _randomForse = Random.Range(200f, 300f);
        _randomTorque = new Vector3(0, 0, Random.Range(100f, 200f));
        _angleRandom = new Vector3(1f, Random.Range(2f, 3f), 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Effect>(out Effect effect))
        {
            //_rigidbody.AddForce(Vector3.up *_randomForse, ForceMode.Impulse);
            _rigidbody.AddTorque(_randomTorque);
            _rigidbody.AddForce(Vector3.up * _randomForse);
            //_rigidbody.AddTorque(0f, 800f, 0f);
        }
    }
}
