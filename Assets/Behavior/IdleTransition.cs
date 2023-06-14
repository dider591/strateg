using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IdleTransition : UnitConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, _unit.CurrentTargetPoint) < _transitionRange)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
