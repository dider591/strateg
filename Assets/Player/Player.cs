using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _bazooka;
    [SerializeField] private Weapon _machineGun;
    public Vector3 Point => hit.point;
    public Weapon CurrentWeapon => _currentWeapon;

    private Weapon _currentWeapon;
    private RaycastHit hit;


    private void Update()
    {
        AimRay();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _bazooka.Shoot();
            Debug.Log("Работает Базука");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _machineGun.Shoot();
            Debug.Log("Работает Пулемет");
        }
    }


    private void AimRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        Physics.Raycast(ray, out hit);
    }

}
