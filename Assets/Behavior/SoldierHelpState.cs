using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SoldierHelpState : UnitAction
{
    [SerializeField] private int _healing;
    [SerializeField] private float _delay;

    private int HelpAnimation = Animator.StringToHash("Help");

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTargetPoint != null)
        {
            _agent.SetDestination(transform.position);

            transform.LookAt(MainTarget.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            Help();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private void Help()
    {
        _animator.Play(HelpAnimation);
        StartCoroutine(ApplyHealing(MainTarget));
    }

    private IEnumerator ApplyHealing(MainTarget mainTarget)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            mainTarget.Healing(_healing);
        }
    }
}
