using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _startButton;

    public UnityAction PlayButtonClick;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _startButton.interactable = false;
    }

    public void OnPlayButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _startButton.interactable = true;
    }
}
