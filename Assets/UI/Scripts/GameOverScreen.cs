using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _closeButton;

    public UnityAction RestartButtonClick;
    public UnityAction CloseButtonClick;
    public UnityAction ExitButtonClick;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    public void OnRestartButtonClick()
    {
        RestartButtonClick.Invoke();
    }

    public void OnCloseButtonClick()
    {
        CloseButtonClick?.Invoke();
    }
    public void OnExitButtonClick()
    {
        ExitButtonClick?.Invoke();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
    }
}
