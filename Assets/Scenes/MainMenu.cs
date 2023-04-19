using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private Button[] _buttons;

    private int _countOpenScene;

    private void OnEnable()
    {
        _countOpenScene = PlayerPrefs.GetInt("levels", 1);
        _menuScreen.OneLevelButtonClick += OnOneLevel;
        _menuScreen.TwoLevelButtonClick += OnTwoLevel;
    }

    private void OnDisable()
    {
        _menuScreen.OneLevelButtonClick -= OnOneLevel;
        _menuScreen.TwoLevelButtonClick -= OnTwoLevel;
    }

    private void Start()
    {
        StartMenu();
    }

    private void OpenLevel()
    {
        for (int i = 0; i < _countOpenScene; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    private void StartMenu()
    {
        Time.timeScale = 0;
        OpenLevel();
    }

    private void OnOneLevel()
    {
        LoadLevel(1);
    }
    private void OnTwoLevel()
    {
        LoadLevel(2);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
