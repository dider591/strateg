using UnityEngine;
using UnityEngine.Events;

public class USAOverviewZone : OverviewZone
{
    public override event UnityAction<Soldier> SawEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierRussia>(out SoldierRussia target))
        {
            SawEnemy?.Invoke(target);
        }
    }
}
