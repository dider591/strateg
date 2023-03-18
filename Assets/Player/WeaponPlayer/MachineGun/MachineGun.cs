using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private float _randomStepPoint;
    [SerializeField] private float _delayShoot;

    public override void Shoot(Vector3 shootPoint)
    {
        LookAim(shootPoint);
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        float pointX;
        float pointY;
        Vector3 correctPoint;

        for (int i = 0; i < CountBullet; i++)
        {
            pointX = Random.Range(transform.position.x - _randomStepPoint, transform.position.x + _randomStepPoint);
            pointY = Random.Range(transform.position.y - _randomStepPoint, transform.position.y + _randomStepPoint);
            correctPoint = new Vector3(pointX, pointY, transform.position.z);

            Instantiate(Bullet, correctPoint, transform.rotation);
            yield return new WaitForSeconds(_delayShoot);
        }
    }
}
