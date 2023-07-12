using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int CountBullet;
    [SerializeField] protected Ammunition Bullet;

    protected Vector3 _shootPoint;
    protected Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public abstract void Shoot();
}
