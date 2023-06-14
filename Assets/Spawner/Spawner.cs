using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;
    [SerializeField] private bool _isReady;
    [SerializeField] private float _delayStartSpawn;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_targetPoint != null || _isReady == true)
        {
            if (other.TryGetComponent<ISetTargetPoint>(out ISetTargetPoint isetTargetPoint))
            {
                isetTargetPoint.SetTargetPoint(_targetPoint.position);
            }
        }
    }

    private void Update()
    {
        if (_targetPoint != null)
        {
            if (_isReady)
            {
                _isReady = false;
                StartCoroutine(InstantiateUnits());
            }
        }
        else
        {
            SearchTargetPoint();
        }
    }

    public void SetReady(bool isReady)
    {
        _isReady = isReady;
    }

    private IEnumerator InstantiateUnits()
    {
        _isReady = false;
        yield return new WaitForSeconds(_delayStartSpawn);

        for (int i = 0; i < _countWaves; i++)
        {
            for (int a = 0; a < _countUnit; a++)
            {
                Instantiate(_unit, _transform.position, _transform.rotation);
            }

            yield return new WaitForSeconds(_stepSpawn);
        }
    }

    private void SearchTargetPoint()
    {
        _targetPoint = FindObjectOfType<SoldierTargetPoint>().transform;
    }
}
