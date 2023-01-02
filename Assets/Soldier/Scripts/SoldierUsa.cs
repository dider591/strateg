using UnityEngine;

public class SoldierUsa : Soldier
{
    public override void SearchTarget()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in _colliders)
        {
            if (collider.TryGetComponent<SoldierRussia>(out SoldierRussia target))
            {
                _target = target;
            }
        }
    }
}
