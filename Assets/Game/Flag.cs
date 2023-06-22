using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MainTarget
{
    [SerializeField] private Transform _flagEnemy;
    [SerializeField] private Transform _flagUSA;
    [SerializeField] private MainTarget _mainTarget;
    [SerializeField] private Bar _flagBar;
    [SerializeField] private Slider _sliderFlag;
    [SerializeField] private Timer _timer;

    private Coroutine _ñhangeFlagCoroutine;
    private bool _isDiedMainTarget = false;
    private int _countRussianSoldiers;
    private int _countUSASoldiers;
    private float _minFlagValue = -4.3f;
    private float _maxFlagValue = 4.3f;
    private float _stepCaptureFlag = 0.002f;

    private void OnEnable()
    {
        _sliderFlag.value = _maxFlagValue;
        _mainTarget.Die += OnDiedMainTarget;
        _timer.TimesUp += OnTimesUp;
        _timer.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _mainTarget.Die -= OnDiedMainTarget;
        _timer.TimesUp -= OnTimesUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isDiedMainTarget)
        {
            if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
            {
                soldierUSA.Dead += OnDiedSoldier;
                _countUSASoldiers++;

                if (_ñhangeFlagCoroutine == null)
                {
                    _ñhangeFlagCoroutine = StartCoroutine(ChangeFlag());
                }
            }
            if (other.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
            {
                soldierRussia.Dead += OnDiedSoldier;
                _countRussianSoldiers++;

                if (_ñhangeFlagCoroutine == null)
                {
                    _ñhangeFlagCoroutine = StartCoroutine(ChangeFlag());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isDiedMainTarget)
        {
            if (other.TryGetComponent<SoldierUSA>(out SoldierUSA soldierUSA))
            {
                soldierUSA.Dead -= OnDiedSoldier;
                OnDiedSoldier(soldierUSA);
            }
            if (other.TryGetComponent<SoldierRussia>(out SoldierRussia soldierRussia))
            {
                soldierRussia.Dead -= OnDiedSoldier;
                OnDiedSoldier(soldierRussia);
            }
        }
    }

    private IEnumerator ChangeFlag()
    {
        while (true)
        {
            float currentFlagValue = _sliderFlag.value;

            if (_countUSASoldiers > _countRussianSoldiers)
            {
                if (currentFlagValue > _minFlagValue)
                {
                    _sliderFlag.value -= _stepCaptureFlag;
                    _flagEnemy.Translate(0, -_stepCaptureFlag, 0);
                    _flagUSA.Translate(0, _stepCaptureFlag, 0);
                }
                else if (currentFlagValue <= _minFlagValue)
                {
                    Win?.Invoke();
                }
            }
            else if (_countUSASoldiers < _countRussianSoldiers)
            {
                if (currentFlagValue < _maxFlagValue)
                {
                    _sliderFlag.value += _stepCaptureFlag;
                    _flagEnemy.Translate(0, _stepCaptureFlag, 0);
                    _flagUSA.Translate(0, -_stepCaptureFlag, 0);
                }
            }
            else if (_countUSASoldiers == 0 && _countRussianSoldiers == 0)
            {
                if (_ñhangeFlagCoroutine != null)
                {
                    StopCoroutine(_ñhangeFlagCoroutine);
                    _ñhangeFlagCoroutine = null;
                }
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

    private void OnDiedMainTarget()
    {
        _taskMessage.Open();
        _flagBar.gameObject.SetActive(true);
        _isDiedMainTarget = true;
    }

    private void OnTimesUp()
    {
        Defeat?.Invoke();
    }
}
