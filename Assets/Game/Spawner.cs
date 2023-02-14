using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private HelicopterMain _helicopterMain;
    [SerializeField] private Unit _unit;
    [SerializeField] private int _countUnit;
    [SerializeField] private int _countWaves;
    [SerializeField] private float _stepSpawn;

    private bool _isCrashed = false;
    private bool _isAllCreated = false;
    protected Vector3 _crashedPoint;

    private void OnEnable()
    {
        _helicopterMain.CrashedPoint += OnHelicopterCrash;
    }

    private void OnDisable()
    {
        _helicopterMain.CrashedPoint -= OnHelicopterCrash;
    }

    private void OnHelicopterCrash(Vector3 target)
    {
        _crashedPoint = target;
        _isCrashed = true;
    }

    private void Update()
    {
        if (_isCrashed && _isAllCreated == false)
        {
            _isAllCreated = true;
            StartCoroutine(InstantiateWaves());
        }
    }

    private IEnumerator InstantiateWaves()
    {
        for (int i = 0; i < _countWaves; i++)
        {
            for (int a = 0; a < _countUnit; a++)
            {
                Instantiate(_unit, transform.position, transform.rotation);
            }

            yield return new WaitForSeconds(_stepSpawn);
        }
    }
}
