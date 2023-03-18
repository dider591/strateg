using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CarSpawnTransition : SoldierConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, Unit.TargetPoint.position) < _transitionRange)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
