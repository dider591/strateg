using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RocketTerrorist : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioSource _audio;

    private Animator animator;
    private float _duration = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Shoot");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Helicopter>(out Helicopter helicopter))
        {
            _effect.Play();
            _audio.Play();
            Destroy(gameObject, _duration);
        }
    }
}
