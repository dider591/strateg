using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] protected int CountBullet;
    [SerializeField] protected Ammunition Bullet;

    private void Update()
    {
        transform.LookAt(_player.Point);
    }

    public abstract void Shoot();
}
