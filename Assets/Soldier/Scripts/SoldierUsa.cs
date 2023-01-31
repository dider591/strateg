using UnityEngine;

public class SoldierUsa : Soldier
{
    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _radius);
        bool _isFindSoldier = false;

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<Target>(out Target target))
            {
                if (target.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
                {
                    if (soldierRussia.Health > 0)
                    {
                        _target = target;
                        _isFindSoldier = true;
                    }
                }
            }
        }
    }
}
