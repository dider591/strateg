using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using DG.Tweening;

public class LandingState : UnitAction
{
    [SerializeField] private float _duration;
    [SerializeField] private float _steep;

    private int _countLoops = 2;
    private bool _endLoop = false;

    public override TaskStatus OnUpdate()
    {
        if (_endLoop == false)
        {
            Loop();
        }
        return TaskStatus.Success;
    }

    private void Loop()
    {
        _agent.enabled = false;
        _transform.DOMoveY(_transform.position.y - _steep, _duration).SetLoops(_countLoops, LoopType.Yoyo);
        _endLoop = true;
        _agent.enabled = true;
    }
}

