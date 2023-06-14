using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetUnitTransition : UnitConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            if (Vector3.Distance(transform.position, _unit.CurrentTarget.transform.position) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
