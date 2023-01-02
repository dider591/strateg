using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Weapon
{
    public override void Shoot(Vector3 shootPoint)
    {
        LookAim(shootPoint);
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}
