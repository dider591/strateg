using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedAmmunition : SharedVariable<Ammunition>
{
    public static implicit operator SharedAmmunition(Ammunition value) => new SharedAmmunition { Value = value };
}
