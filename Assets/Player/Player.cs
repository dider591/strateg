using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _bazooka;
    [SerializeField] private Weapon _machineGun;
    [SerializeField] private GameScreen _gameScreen;
    public Weapon CurrentWeapon => _currentWeapon;

    private Weapon _currentWeapon;
    private RaycastHit hit;

    private void OnEnable()
    {
        _gameScreen.MachineGunButtonClick += OnMachineGunButtonClick;
        _gameScreen.MessileButtonClick += OnMessileButtonClick;
    }

    private void OnDisable()
    {
        _gameScreen.MachineGunButtonClick -= OnMachineGunButtonClick;
        _gameScreen.MessileButtonClick -= OnMessileButtonClick;
    }

    private void Update()
    {
        AimRay();
    }

    public void Shooting(Weapon weapon)
    {
        weapon.Shoot(hit.point);
    }

    private void OnMachineGunButtonClick()
    {
        Shooting(_machineGun);
    }

    private void OnMessileButtonClick()
    {
        Shooting(_bazooka);
    }

    private void AimRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        Physics.Raycast(ray, out hit);
    }
}
