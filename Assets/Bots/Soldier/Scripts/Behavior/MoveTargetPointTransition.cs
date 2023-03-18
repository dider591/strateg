using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetPointTransition : SoldierConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (Unit.TargetPoint != null)
        {
            if (Unit.Target == null && Vector3.Distance(transform.position, Unit.TargetPoint.position) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
