using UnityEngine;

public class Bazooka : Weapon
{
    public override void Shoot()
    {
        Instantiate(Bullet, _transform.position, _transform.rotation);
    }
}
