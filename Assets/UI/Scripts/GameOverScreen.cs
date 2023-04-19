using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _selectLevelButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _selectLevelButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _selectLevelButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _restartButton.interactable = false;
        _selectLevelButton.interactable = false;
    }

    public void OnRestartButtonClick()
    {
        int lastScene = PlayerPrefs.GetInt("levels");
        SceneManager.LoadScene(lastScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _restartButton.interactable = true;
        _selectLevelButton.interactable = true;
    }

    //public void OnSceneLoaded(TypedScene lastScene)
    //{
    //    _lastScene = lastScene;
    //}
}
