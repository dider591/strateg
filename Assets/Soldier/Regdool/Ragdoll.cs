using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allBones;

    private void Awake()
    {
        foreach (var bones in _allBones)
        {
            //bones.AddForce(0.1f, 0f, 0f);
            bones.isKinematic = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnDied();
        }
    }

    public void OnDied()
    {    
        foreach (var bones in _allBones)
        {
            bones.AddForce(5f, 0f, 0f);
            bones.isKinematic = false;
        }

        // Destroy(gameObject, 4f);
    }
}
