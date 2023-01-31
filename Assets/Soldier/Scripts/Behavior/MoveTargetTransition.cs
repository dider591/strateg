using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveTargetTransition : SoldierConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (_soldier.Target != null)
        {
            if (Vector3.Distance(transform.position, _soldier.Target.transform.position) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
