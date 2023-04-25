using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _restartButton.interactable = true;
        _mainMenuButton.interactable = true;
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _restartButton.interactable = false;
        _mainMenuButton.interactable = false;
    }

    public void OnRestartButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(0);
    }

}
