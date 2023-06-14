using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MachinegannerAttackState : UnitAction
{
    [SerializeField] private Ammunition _ammunition;
    [SerializeField] private Transform _shootPoint;
    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTarget != null)
        {
            transform.LookAt(_unit.CurrentTarget.transform.position);
            Shoot();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private void Shoot()
    {
        GameObject.Instantiate(_ammunition, _shootPoint.transform.position, _shootPoint.transform.rotation);
    }
}
