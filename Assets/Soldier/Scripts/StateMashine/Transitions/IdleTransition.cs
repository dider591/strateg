using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {

        if (Target == null && (transform.position.x == StartPoint.x && transform.position.z == StartPoint.z))
        {
            NeedTransit = true;
        }
    }
}
