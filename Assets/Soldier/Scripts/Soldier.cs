using UnityEngine;
using UnityEngine.Events;

public abstract class Soldier : MonoBehaviour
{
    [SerializeField] protected float _radius;
    [SerializeField] private int _health;
    [SerializeField] private Ragdoll _ragdoll;

    protected Target _target;
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
        Debug.Log("Soldier");
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke();
            OnDied();
        }
    }

    public void OnDied()
    {
        //_ragdoll.ActivateRagdoll();
        Instantiate(_ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void SetCrashPoint(Vector3 point)
    {
        float pointX = Random.Range(point.x - _randomStepPoint, point.x + _randomStepPoint);
        float pointZ = Random.Range(point.z - _randomStepPoint, point.z + _randomStepPoint);
        Vector3 correctPoint = new Vector3(pointX, point.y, pointZ);

        _crashPoint = correctPoint;
    }

    public abstract void SearchTarget();
}
