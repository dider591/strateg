using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allBones;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        _animator.enabled = true;

        foreach (var bones in _allBones)
        {
            bones.isKinematic = true;
        }
    }

    public void ActivateRagdoll()
    {
        _animator.enabled = false;

        foreach (var bones in _allBones)
        {
            //bones.AddForce(15f, 0f, 0f);
            bones.isKinematic = false;
        }
    }
}
