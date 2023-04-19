using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetPointTransition : UnitConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTargetPoint != null)
        {
            if (/*_unit.CurrentTarget == null &&*/ Vector3.Distance(transform.position, _unit.CurrentTargetPoint) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
