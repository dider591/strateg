using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public abstract class UnitConditional : Conditional
{
    protected Unit _unit;
    protected MainTarget Helicopter;

    public override void OnAwake()
    {
        _unit = GetComponent<Unit>();

        if (this.GetComponent<SoldierUSA>())
        {
            Helicopter = GetComponent<SoldierUSA>().MainTarget;
        }
    }
}
