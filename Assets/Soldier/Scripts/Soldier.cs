using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : MonoBehaviour
{
    [SerializeField] protected float _radius;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _healing;
    [SerializeField] private int _health;
    [SerializeField] private Ragdoll _ragdoll;

    protected Target _target;
    protected Coroutine _applyDamage;
    protected Coroutine _applyHealing;
    protected float _delay = 5f;
    private Vector3 _crashPoint;
    private float _randomStepPoint = 0.5f;

    public Target Target => _target;
    public int Health => _health;
    public Vector3 CrashPoint => _crashPoint;

    public event UnityAction Dying;

    private void Update()
    {
        if (_target == null)
        {
            SearchTarget();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke();
            OnDied();
        }
    }

    public void OnDied()
    {
        Instantiate(_ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void SetCrashPoint(Vector3 point)
    {
        float pointX = Random.Range(point.x - _randomStepPoint, point.x + _randomStepPoint);
        float pointZ = Random.Range(point.z - _randomStepPoint, point.z + _randomStepPoint);
        Vector3 correctPoint = new Vector3(pointX, point.y, pointZ);

        _crashPoint = correctPoint;
        Debug.Log("Soldier point = " + _crashPoint);
    }

    public abstract void SearchTarget();

    internal void TakeDamage(object damage)
    {
        throw new System.NotImplementedException();
    }
}
