using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SoldierHelpState : UnitAction
{
    [SerializeField] private float _healing;
    [SerializeField] private float _delayHealing;

    private int HelpAnimation = Animator.StringToHash("Help");
    private bool _isApplyHealing = false;
    private Coroutine _coroutineHelp;

    public override TaskStatus OnUpdate()
    {
        if (_unit.CurrentTargetPoint != null)
        {
            _agent.SetDestination(transform.position);
            _animator.Play(HelpAnimation);
            transform.LookAt(_unit.CurrentTargetPoint);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (_isApplyHealing == false)
            {
                _isApplyHealing = true;
                _coroutineHelp = StartCoroutine(Help());
            }

            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private IEnumerator Help()
    {
        _unit.CurrentMainTarget.Healing(_healing);

         yield return new WaitForSeconds(_delayHealing);
        _isApplyHealing = false;
    }
}
