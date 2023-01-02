using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Soldier Target;
    protected Vector3 StartPoint;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Soldier target, Vector3 startPoint)
    {
        Target = target;
        StartPoint = startPoint;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
