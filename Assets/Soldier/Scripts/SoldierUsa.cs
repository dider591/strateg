using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUSA : Soldier
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HelicopterMain>(out HelicopterMain helicopterMain))
        {
            _applyDamage = StartCoroutine(ApplyDamage(helicopterMain));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<HelicopterMain>(out HelicopterMain helicopterMain))
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
                if (targetUnit.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia) && targetUnit.Health > 0)
                {
                    _target = targetUnit;
                }
            }
        }
    }

    private IEnumerator ApplyDamage(HelicopterMain helicopterMain)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            helicopterMain.TakeDamage(_damage);
        }
    }
}
