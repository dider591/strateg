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

    protected Vector3 _crashedPoint;
    private bool _isCrashed = false;
    private bool _isAllCreated = false;
    private bool _isTwoWave = false;

    private int _coefficient = 5;

    private void OnEnable()
    {
        _helicopterMain.CrashedPoint += OnHelicopterCrash;
        _helicopterMain.Healed += OnHealed;
    }

    private void OnDisable()
    {
        _helicopterMain.CrashedPoint -= OnHelicopterCrash;
        _helicopterMain.Healed -= OnHealed;
    }

    private void OnHelicopterCrash(Vector3 target)
    {
        _crashedPoint = target;
        _isCrashed = true;
        Debug.Log("Spawner point = " + _crashedPoint);
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

    private void OnHealed()
    {
        _countWaves += _coefficient;
        _countUnit += _coefficient;
        _isTwoWave = true;
        _isAllCreated = false;
    }
}
