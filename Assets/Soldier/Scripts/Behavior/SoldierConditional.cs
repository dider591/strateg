using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public abstract class SoldierConditional : Conditional
{
    protected Soldier _soldier;

    public override void OnAwake()
    {
        _soldier = GetComponent<Soldier>();
    }
}
