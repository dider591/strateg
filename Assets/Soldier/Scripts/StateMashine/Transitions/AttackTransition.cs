using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Target != null && Vector3.Distance(transform.position, Target.transform.position) <= _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
