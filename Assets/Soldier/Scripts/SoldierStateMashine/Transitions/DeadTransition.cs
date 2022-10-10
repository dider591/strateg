using UnityEngine;

[RequireComponent(typeof(Soldier))]
public class DeadTransition : Transition
{
    private Soldier _soldier;
    private bool isDead = false;

    private void OnEnable()
    {
        _soldier = GetComponent<Soldier>();
        _soldier.Dying += onDamage;
    }

    private void onDamage()
    {
        isDead = true;
    }

    private void OnDisable()
    {
        _soldier.Dying -= onDamage;
    }

    private void Update()
    {
        if (isDead == true)
        {
            NeedTransit = true;
        }
    }
}
