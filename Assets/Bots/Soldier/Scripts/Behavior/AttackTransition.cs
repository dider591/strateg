using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackTransition : SoldierConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (Unit.Target != null)
        {
            if (Vector3.Distance(transform.position, Unit.Target.transform.position) < _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
