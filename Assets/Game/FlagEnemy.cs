using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlagEnemy : Mission
{
    [SerializeField] private Transform _flagEnemy;
    [SerializeField] private Transform _flagUSA;
    [SerializeField] private Bar _flagBar;
    [SerializeField] private Slider _sliderFlag;
    [SerializeField] private Timer _timer;

    private float _stepFlagCapture = 0.002f;
    private Coroutine _ñhangeFlagCoroutine;
    private int _countRussianSoldiers;
    private int _countUSASoldiers;
    private float _minFlagValue = -4.3f;
    private float _maxFlagValue = 4.3f;
    private bool _isMissionStart = false;

    public override void Init()
    {
        _taskMessage.Open();
        _isMissionStart = true;
        _flagBar.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _sliderFlag.value = _maxFlagValue;
        _timer.TimesUp += OnTimesUp;
        _timer.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _timer.TimesUp -= OnTimesUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isMissionStart == true)
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

    private IEnumerator ChangeFlag()
    {
        while (true)
        {
            float currentFlagValue = _sliderFlag.value;

            if (_countUSASoldiers > _countRussianSoldiers)
            {
                if (currentFlagValue > _minFlagValue)
                {
                    _sliderFlag.value -= _stepFlagCapture;
                    _flagEnemy.Translate(0, -_stepFlagCapture, 0);
                    _flagUSA.Translate(0, _stepFlagCapture, 0);
                }
                else if (currentFlagValue <= _minFlagValue && _isWin == false)
                {
                    _isWin = true;
                    Win?.Invoke();
                }
            }
            else if (_countUSASoldiers < _countRussianSoldiers)
            {
                if (currentFlagValue < _maxFlagValue)
                {
                    _sliderFlag.value += _stepFlagCapture;
                    _flagEnemy.Translate(0, _stepFlagCapture, 0);
                    _flagUSA.Translate(0, -_stepFlagCapture, 0);
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

    private void OnTimesUp()
    {
        Defeat?.Invoke();
    }
}
