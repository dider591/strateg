using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : Unit, ITakeDamage, IDeath
{
    [SerializeField] protected int _healing;

    protected Coroutine _applyDamage;
    protected Coroutine _applyHealing;
    protected float _delay = 5f;

    //private void Start()
    //{
    //    SetTargetPoint();
    //}

    private void Update()
    {
        if (Target == null)
        {
            SearchTarget();
        }
        if (Target != null && Target.Health <= 0)
        {
            CurrentTarget = null;
            SearchTarget();
        }
    }

    //public void SetTargetPoint()
    //{
    //    CurrentTargetPoint = FindObjectOfType<SoldierTargetPoint>().transform;
    //}

    public abstract void SearchTarget();

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (!_isDead)
        {
            FindObjectOfType<Player>().AddManey(_reward);
            _ragdoll.Disable();
        }

        _isDead = true;
    }
}
