using UnityEngine;

public class SoldierRussia : Soldier
{
    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<SoldierUsa>(out SoldierUsa target))
            {
                _target = target;
            }
        }
    }
}
