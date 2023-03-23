using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUSA : Soldier
{
    [SerializeField] protected int _healing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FallenHelicopter>(out FallenHelicopter helicopterMain))
        {
            _applyHealing = StartCoroutine(ApplyHealing(helicopterMain));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FallenHelicopter>(out FallenHelicopter helicopterMain))
        {
            StopCoroutine(_applyHealing);
        }
    }

    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, SearchRadius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<Unit>(out Unit targetUnit))
            {
                if (targetUnit.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia) && targetUnit.CurrentHealth > 0)
                {
                    Target = targetUnit;
                }
            }
        }
    }

    private IEnumerator ApplyHealing(FallenHelicopter helicopterMain)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            helicopterMain.Healing(_healing);
        }
    }
}
