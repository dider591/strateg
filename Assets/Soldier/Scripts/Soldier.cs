using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : Unit
{
    [SerializeField] protected float _radius;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _healing;

    protected Unit _target;
    protected Coroutine _applyDamage;
    protected Coroutine _applyHealing;
    protected float _delay = 5f;

    private float _randomStepPoint = 0.5f;
    private Ragdoll _ragdoll;

    public Unit Target => _target;

    public Vector3 CrashPoint => _crashPoint;

    public event UnityAction Dying;

    private void Awake()
    {
        _ragdoll = GetComponent<Ragdoll>();
    }

    private void Update()
    {
        if(_target == null)
        {
            SearchTarget();
        }
        if (_target != null && _target.Health <= 0)
        {
            _target = null;
            SearchTarget();
        }
    }

    public void SetCrashPoint(Vector3 point)
    {
        float pointX = Random.Range(point.x - _randomStepPoint, point.x + _randomStepPoint);
        float pointZ = Random.Range(point.z - _randomStepPoint, point.z + _randomStepPoint);
        Vector3 correctPoint = new Vector3(pointX, point.y, pointZ);

        _crashPoint = correctPoint;
    }

    public abstract void SearchTarget();

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke();
            _ragdoll.Disable();
        }
    }
}
