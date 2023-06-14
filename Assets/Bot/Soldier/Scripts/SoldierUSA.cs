using UnityEngine;

public class SoldierUSA : Soldier
{
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
                    return;
                }
                if (targetUnit.TryGetComponent<CarRussia>(out CarRussia carRussia) && targetUnit.CurrentHealth > 0)
                {
                    Target = carRussia;
                }
            }
        }
    }
}
