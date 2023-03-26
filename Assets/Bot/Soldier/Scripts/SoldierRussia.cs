using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRussia : Soldier
{
    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, SearchRadius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<Unit>(out Unit targetUnit))
            {
                if (targetUnit.TryGetComponent<SoldierUSA> (out SoldierUSA soldierUSA) && targetUnit.CurrentHealth > 0)
                {
                    Target = soldierUSA;
                    return;
                }
                if (targetUnit.TryGetComponent<CarUSA>(out CarUSA carUSA) && targetUnit.CurrentHealth > 0)
                {
                    Target = carUSA;
                    return;
                }
                if (targetUnit.TryGetComponent<FallenHelicopter>(out FallenHelicopter fallenHelicopter))
                {
                    Target = fallenHelicopter;
                }
            }
        }
    }
}
