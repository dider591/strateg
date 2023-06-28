using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Boats : Mission
{
    [SerializeField] private Car[] _boats;
    [SerializeField] private Text _textCountBunkers;
    [SerializeField] private Bar _boatsBar;

    private int _countBoats;
    private float _sizeFillBoat = 0.17f;
    private float _currentFillSize;
    private float _timeDelayTask = 4f;

    public UnityAction AllDestroyed;

    private void OnEnable()
    {
        foreach (var boat in _boats)
        {
            boat.Dead += OnChangeCountBoats;
        }
    }

    private void OnDisable()
    {
        foreach (var boat in _boats)
        {
            boat.Dead -= OnChangeCountBoats;
        }
    }

    public override void Init()
    {
        _countBoats = _boats.Length;
        _currentFillSize = 1f;
        _textCountBunkers.text = _countBoats.ToString();
        Invoke(nameof(StartTaskMessage), _timeDelayTask);
    }

    private void OnChangeCountBoats()
    {
        _countBoats--;
        _textCountBunkers.text = _countBoats.ToString();
        _currentFillSize -= _sizeFillBoat;
        ProgressChanged?.Invoke(_currentFillSize);

        if (_countBoats <= 0)
        {
            Win?.Invoke();
            _boatsBar.gameObject.SetActive(false);
        }
    }

    private void StartTaskMessage()
    {
        _taskMessage.Open();
    }
}
