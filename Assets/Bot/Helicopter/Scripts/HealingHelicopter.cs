using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHelicopter : MonoBehaviour
{
    [SerializeField] private float _healing;

    private Helicopter _helicopter;
    private Coroutine _coroutineHeal;
    private int _countSoldiers;

    private void Start()
    {
        _helicopter = GetComponentInParent<Helicopter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
        {
            if (soldierUSA.TryGetComponent<Medic>(out Medic medic))
            {
                soldierUSA.Dead += OnDiedSoldier;
                _countSoldiers++;

                if (_coroutineHeal == null)
                {
                    _coroutineHeal = StartCoroutine(Heal());
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
        {
            if (soldierUSA.TryGetComponent<Medic>(out Medic medic))
            {
                soldierUSA.Dead -= OnDiedSoldier;
                OnDiedSoldier(soldierUSA);
            }
        }
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            if (_countSoldiers > 0)
            {
                _helicopter.Heal(_healing);
            }
            else if (_countSoldiers <= 0)
            {
                if (_coroutineHeal != null)
                {
                    StopCoroutine(_coroutineHeal);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDiedSoldier(Soldier soldier)
    {
        if (soldier.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
        {
            if (_countSoldiers > 0)
            {
                _countSoldiers--;
            }
        }
    }
}
