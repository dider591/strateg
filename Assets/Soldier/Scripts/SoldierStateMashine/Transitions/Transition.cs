using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Soldier Target;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Soldier target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
