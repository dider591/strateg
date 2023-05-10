using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLastScreen : Screen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _coinCount;

    private void OnEnable()
    {
        _coinCount.text = PlayerPrefs.GetInt("score").ToString();
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _mainMenuButton.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
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
