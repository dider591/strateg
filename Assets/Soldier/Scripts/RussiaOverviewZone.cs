using UnityEngine;
using UnityEngine.Events;

public class RussiaOverviewZone : OverviewZone
{
    public override event UnityAction<Soldier> SawEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierUsa>(out SoldierUsa target))
        {
            SawEnemy?.Invoke(target);
        }
    }
}
