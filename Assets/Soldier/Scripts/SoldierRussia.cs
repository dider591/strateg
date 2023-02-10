using System.Collections;
using UnityEngine;

public class SoldierRussia : Soldier
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
            if (collider.TryGetComponent<Target>(out Target target))
            {
                if (target.TryGetComponent<SoldierUsa>(out SoldierUsa soldierUsa))
                {
                    if (soldierUsa.Health > 0)
                    {
                        _target = target;
                    }
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
