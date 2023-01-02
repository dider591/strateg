using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Target != null && Vector3.Distance(transform.position, Target.transform.position) > _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
