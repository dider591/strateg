using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRussia : Soldier
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Helicopter>(out Helicopter helicopterMain))
        {
            _applyDamage = StartCoroutine(ApplyDamage(helicopterMain));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Helicopter>(out Helicopter helicopterMain))
        {
            StopCoroutine(_applyDamage);
        }
    }

    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<Unit>(out Unit targetUnit))
            {
                if (targetUnit.TryGetComponent<SoldierUSA> (out SoldierUSA soldierUSA) && targetUnit.Health > 0)
                {
                    CurrentTarget = targetUnit;
                }
            }
        }
    }

    private IEnumerator ApplyDamage(Helicopter helicopterMain)
    {
        while (true)
        {
            Debug.Log("damage");
            yield return new WaitForSeconds(_delay);
            helicopterMain.TakeDamage(_damage);
        }
    }
}
