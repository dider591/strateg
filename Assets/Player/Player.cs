using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _bazooka;
    [SerializeField] private Weapon _machineGun;
    [SerializeField] private Squad _squad;
    [SerializeField] private Weapon _artStrike;
    //[SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Button _squadButton;
    [SerializeField] private Button _machineGunButton;
    [SerializeField] private Button _missileButton;
    [SerializeField] private Button _artStrikeButton;

    private int _maney;
    private int _startCountManey = 100;
    private Weapon _currentWeapon;
    private RaycastHit _hit;

    public Weapon CurrentWeapon => _currentWeapon;
    public int Maney => _maney;

    public UnityAction<int> ChangedManeyCount;

    private void OnEnable()
    {
        AddManey(_startCountManey);
        _machineGunButton.onClick.AddListener(OnMachineGunButtonClick);
        _missileButton.onClick.AddListener(OnMessileButtonClick);
        _squadButton.onClick.AddListener(OnSquadButtonClick);
        _artStrikeButton.onClick.AddListener(OnArtStrakeButtonClick);
    }
    private void OnDisable()
    {
        _machineGunButton.onClick.RemoveListener(OnMachineGunButtonClick);
        _missileButton.onClick.RemoveListener(OnMessileButtonClick);
        _squadButton.onClick.RemoveListener(OnSquadButtonClick);
        _artStrikeButton.onClick.RemoveListener(OnArtStrakeButtonClick);
    }

    public void Shooting(Weapon weapon)
    {
        weapon.Shoot(/*_hit.point*/);
    }

    public void AddManey(int maneyCount)
    {
        _maney += maneyCount;
        ChangedManeyCount?.Invoke(_maney);
    }

    public void ReducesManey(int price)
    {
        _maney -= price;
        ChangedManeyCount?.Invoke(_maney);
    }

    private void OnArtStrakeButtonClick()
    {
        Shooting(_artStrike);
    }

    private void OnSquadButtonClick()
    {
        _squad.OnSquadsButtonClick();
    }

    private void Update()
    {
        AimRay();
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

        Physics.Raycast(ray, out _hit);
    }
}
