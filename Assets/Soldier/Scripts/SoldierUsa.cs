using System.Collections;
using UnityEngine;

public class SoldierUsa : Soldier
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
            if (collider.TryGetComponent<Target>(out Target target))
            {
                if (target.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
                {
                    if (soldierRussia.Health > 0)
                    {
                        _target = target;
                    }
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
