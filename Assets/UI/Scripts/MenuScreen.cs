using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : Screen
{
    [SerializeField] private Button _oneLevel;
    [SerializeField] private Button _twoLevel;

    public UnityAction OneLevelButtonClick;
    public UnityAction TwoLevelButtonClick;

    private void OnEnable()
    {
        _oneLevel.onClick.AddListener(OnOneLevelButtonClick);
        _twoLevel.onClick.AddListener(OnTwoLevelButtonClick);
    }

    private void OnDisable()
    {
        _oneLevel.onClick.RemoveListener(OnOneLevelButtonClick);
        _twoLevel.onClick.RemoveListener(OnTwoLevelButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _oneLevel.interactable = false;
    }

    public void OnOneLevelButtonClick()
    {
        Debug.Log("level1");
        OneLevelButtonClick?.Invoke();
    }

    public void OnTwoLevelButtonClick()
    {
        Debug.Log("level2");
        TwoLevelButtonClick?.Invoke();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _oneLevel.interactable = true;
    }
}
