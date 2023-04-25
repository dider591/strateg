using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : Screen
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _nextLevelButton.interactable = false;
        _mainMenuButton.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _nextLevelButton.interactable = true;
        _mainMenuButton.interactable = true;
    }

    public void OnNextLevelButtonClick()
    {
        int lastScene = PlayerPrefs.GetInt("levels");
        SceneManager.LoadScene(lastScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
