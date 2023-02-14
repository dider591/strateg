using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveHelicopterTransition : SoldierConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (_soldier.CrashPoint != null)
        {
            if (_soldier.Target == null && Vector3.Distance(transform.position, _soldier.CrashPoint) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}