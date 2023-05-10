using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : Unit, ITakeDamage, ISetTargetPoint
{
    [SerializeField] protected int _damage;

    protected Coroutine _applyHealing;
    protected float _delay = 5f;

    public UnityAction<Soldier> Dead;

    private float _randomStepPoint = 1f;
    private bool _isDead;

    public void SetTargetPoint(Vector3 point)
    {
        float pointX = Random.Range(point.x - _randomStepPoint, point.x + _randomStepPoint);
        float pointZ = Random.Range(point.z - _randomStepPoint, point.z + _randomStepPoint);
        Vector3 correctPoint = new Vector3(pointX, point.y, pointZ);

        TargetPoint = correctPoint;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Death();
        }
    }

    public override void Death()
    {
        if (_isDead == false)
        {
            FindObjectOfType<Player>().AddManey(Reward);
            Dead?.Invoke(this);
            Ragdoll.Disable();
        }

        _isDead = true;
    }
}
