using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MainTarget, IGameOver
{
    [SerializeField] private Transform _flagEnemy;
    [SerializeField] private Transform _flagUSA;
    [SerializeField] private Building[] _buildings;
    [SerializeField] private Text _textCountBuildings;
    [SerializeField] private Bar _bunkersBar;
    [SerializeField] private Bar _flagBar;
    [SerializeField] private Slider _sliderFlag;

    private Coroutine _ChangeFlagCoroutine;
    private bool _isAllBunkersAlive = true;
    private float _currentFillSize;
    private int _countBuildings;
    private float _sizeBuilding = 0.17f;
    private int _countRussianSoldiers;
    private int _countUSASoldiers;
    private float _minFlagValue = -4.33f;
    private float _maxFlagValue = 4.33f;
    private float _stepCaptureFlag = 0.002f;

    private void OnEnable()
    {
        _sliderFlag.value = _maxFlagValue;
        _countBuildings = _buildings.Length;
        _textCountBuildings.text = _countBuildings.ToString();
        _currentFillSize = 1f;

        foreach (var building in _buildings)
        {
            building.Dead += OnChangeCountBuildings;
        }
    }

    private void OnDisable()
    {
        foreach (var building in _buildings)
        {
            building.Dead -= OnChangeCountBuildings;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isAllBunkersAlive)
        {
            if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
            {
                soldierUSA.Dead += OnDiedSoldier;
                _countUSASoldiers++;

                if (_ChangeFlagCoroutine == null)
                {
                    _ChangeFlagCoroutine = StartCoroutine(ChangeFlag());
                }
            }
            if (other.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
            {
                soldierRussia.Dead += OnDiedSoldier;
                _countRussianSoldiers++;

                if (_ChangeFlagCoroutine == null)
                {
                    _ChangeFlagCoroutine = StartCoroutine(ChangeFlag());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isAllBunkersAlive)
        {
            if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
            {
                soldierUSA.Dead -= OnDiedSoldier;
                _countUSASoldiers--;
            }
            if (other.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
            {
                soldierRussia.Dead -= OnDiedSoldier;
                _countRussianSoldiers--;
            }
        }
    }

    private IEnumerator ChangeFlag()
    {
        while (true)
        {
            if (_countUSASoldiers > _countRussianSoldiers)
            {
                if (_sliderFlag.value > _minFlagValue)
                {
                    Debug.Log("min");
                    _sliderFlag.value -= _stepCaptureFlag;
                    _flagEnemy.Translate(0, -_stepCaptureFlag, 0);
                    _flagUSA.Translate(0, _stepCaptureFlag, 0);
                }
            }
            else if (_countUSASoldiers < _countRussianSoldiers)
            {
                if (_sliderFlag.value < _maxFlagValue)
                {
                    Debug.Log("max");
                    _sliderFlag.value += _stepCaptureFlag;
                    _flagEnemy.Translate(0, _stepCaptureFlag, 0);
                    _flagUSA.Translate(0, -_stepCaptureFlag, 0);
                }
            }
            else if (_countUSASoldiers == 0 && _countRussianSoldiers == 0)
            {
                Debug.Log("Stop Coroutine");
                StopCoroutine(_ChangeFlagCoroutine);
                _ChangeFlagCoroutine = null;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDiedSoldier(Soldier soldier)
    {
        if (soldier.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
        {
            if (_countUSASoldiers > 0)
            {
                _countUSASoldiers--;
            }
        }
        if (soldier.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
        {
            if (_countRussianSoldiers > 0)
            {
                _countRussianSoldiers--;
            }
        }
    }

    public void GameOver()
    {

    }

    private void OnChangeCountBuildings()
    {
        _countBuildings--;
        _textCountBuildings.text = _countBuildings.ToString();
        _currentFillSize -= _sizeBuilding;
        ProgressChanged?.Invoke(_currentFillSize);

        if (_countBuildings <= 0)
        {
            _isAllBunkersAlive = false;
            SwitchesBar();
        }
    }

    private void SwitchesBar()
    {
        _bunkersBar.gameObject.SetActive(false);
        _flagBar.gameObject.SetActive(true);
    }
}
