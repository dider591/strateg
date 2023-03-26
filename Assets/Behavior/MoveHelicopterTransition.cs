using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveHelicopterTransition : UnitConditional
{
    [SerializeField] private float _transitionRange;

    public override TaskStatus OnUpdate()
    {
        if (Helicopter != null)
        {
            if (_unit.CurrentTarget == null && Vector3.Distance(transform.position, Helicopter.transform.position) >= _transitionRange)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
