using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bunkers : Mission
{
    [SerializeField] private Building[] _buildings;
    [SerializeField] private Text _textCountBunkers;
    [SerializeField] private Bar _bunkersBar;

    private int _countBuildings;
    private float _sizeBuilding = 0.17f;
    private float _currentFillSize;
    private float _timeDelayTask = 4f;

    public UnityAction AllDestroyed;

    private void OnEnable()
    {
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

    public override void Init()
    {
        _countBuildings = _buildings.Length;
        _currentFillSize = 1f;
        _textCountBunkers.text = _countBuildings.ToString();
        Invoke(nameof(StartTaskMessage), _timeDelayTask);
    }

    private void OnChangeCountBuildings()
    {
        _countBuildings--;
        _textCountBunkers.text = _countBuildings.ToString();
        _currentFillSize -= _sizeBuilding;
        ProgressChanged?.Invoke(_currentFillSize);

        if (_countBuildings <= 0)
        {
            Win?.Invoke();
            _bunkersBar.gameObject.SetActive(false);
        }
    }

    private void StartTaskMessage()
    {
        _taskMessage.Open();
    }

}
