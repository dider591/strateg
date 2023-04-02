using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTerrorist : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectBoom;
    [SerializeField] private AudioSource _audioBoom;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _helicopterPoint;
    [SerializeField] private float _minDistance;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private int _damage;

    private bool _isPlayAudio = false;

    private float _distance;

    private void Update()
    {
        transform.LookAt(_helicopterPoint);
        _distance = Vector3.Distance(transform.position, _helicopterPoint.position);

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
        if (other.TryGetComponent<MainTarget>(out MainTarget mainTarget))
        {
            Instantiate(_effectBoom, transform.position, transform.rotation);
            mainTarget.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
