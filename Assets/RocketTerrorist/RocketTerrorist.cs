using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTerrorist : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectBoom;
    [SerializeField] private AudioSource _audioBoom;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _helicopter;
    [SerializeField] private float _minDistance;
    [SerializeField] private AudioSource _audio;

    private bool _isPlayAudio = false;

    private float _distance;

    private void Update()
    {
        transform.LookAt(_helicopter);
        _distance = Vector3.Distance(transform.position, _helicopter.position);

        if (_distance < _minDistance)
        {
            Move();
        }
    }

    private void Move()
    {
        if (!_isPlayAudio)
        {
            _isPlayAudio = true;
            _audio.Play();
        }

        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Helicopter>(out Helicopter helicopter))
        {
            //_effectBoom.Play();
            //_audioBoom.Play();
            Instantiate(_effectBoom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
