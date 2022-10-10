using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private float _maxTransitionRange;
    [SerializeField] private float _minTransitionRange;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) <= _maxTransitionRange && Vector3.Distance(transform.position, Target.transform.position) > _minTransitionRange)
        {
            NeedTransit = true;
        }
    }
}
