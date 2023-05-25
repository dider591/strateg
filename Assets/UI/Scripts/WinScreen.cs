using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : Screen
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _coinCount;

    private int _nextScene = 1;

    private void OnEnable()
    {
        _coinCount.text = PlayerPrefs.GetInt("score").ToString();
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
        _canvas.blocksRaycasts = false;
        _canvas.interactable = false;
        //_nextLevelButton.interactable = false;
        //_mainMenuButton.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.blocksRaycasts = true;
        _canvas.interactable = true;
        //_nextLevelButton.interactable = true;
        //_mainMenuButton.interactable = true;
    }

    public void OnNextLevelButtonClick()
    {
        int lastScene = PlayerPrefs.GetInt("levels") + _nextScene;
        SceneManager.LoadScene(lastScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
