using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    public override void Shoot(Vector3 shootPoint)
    {
        LookAim(shootPoint);
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        for (int i = 0; i < CountBullet; i++)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
