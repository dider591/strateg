using UnityEngine;
using UnityEngine.Events;

public abstract class OverviewZone : MonoBehaviour
{
    public abstract event UnityAction<Soldier> SawEnemy;
}
