using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public abstract class SoldierConditional : Conditional
{
    protected Unit Unit;

    public override void OnAwake()
    {
        Unit = GetComponent<Unit>();
    }
}
