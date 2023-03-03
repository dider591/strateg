using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUSA : Soldier
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HelicopterMain>(out HelicopterMain helicopterMain))
        {
            _applyHealing = StartCoroutine(ApplyHealing(helicopterMain));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<HelicopterMain>(out HelicopterMain helicopterMain))
        {
            StopCoroutine(_applyHealing);
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

    private IEnumerator ApplyHealing(HelicopterMain helicopterMain)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            helicopterMain.Healing(_healing);
        }
    }
}
