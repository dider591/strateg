using UnityEngine;

[RequireComponent(typeof(Soldier))]
public class SoldierStateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Soldier _target;
    private Vector3 _startPoint;
    public Soldier Target => _target;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Soldier>().Target;
        _startPoint = transform.position;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }

    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target, _startPoint);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target, _startPoint);
        }
    }
}
