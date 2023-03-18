using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;
    [SerializeField] protected float _radius;
    [SerializeField] protected int _damage;

    protected Unit CurrentTarget;
    protected Transform CurrentTargetPoint;
    protected bool _isDead;
    protected Ragdoll _ragdoll;

    private float _randomStepPoint = 0.5f;

    public event UnityAction Dying;

    public int Health => _health;
    public Unit Target => CurrentTarget;
    public Transform TargetPoint => CurrentTargetPoint; //ћы пытаемс€ получить раньше чем устанавливаем ниже. возможно из за этого ошибка
                                                        //Ќужно добавить анимацию машине
    private void Awake()
    {
        _ragdoll = GetComponent<Ragdoll>();
    }

        //float pointX = Random.Range(transform.position.x - _randomStepPoint, transform.position.x + _randomStepPoint);
        //float pointZ = Random.Range(transform.position.z - _randomStepPoint, transform.position.z + _randomStepPoint);
        //Vector3 correctPoint = new Vector3(pointX, transform.position.y, pointZ);

        //TargetPoint.position = correctPoint;

        //CurrentTargetPoint = transform;
    public void SetTargetPoint(Transform point)
    {
        CurrentTargetPoint = point;
    }

}
