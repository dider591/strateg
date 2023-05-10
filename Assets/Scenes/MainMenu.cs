using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private Button[] _buttons;

    private int _levelInLock;

    private void OnEnable()
    {
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
        PlayerPrefs.SetInt("scenes", 1);
        _levelInLock = PlayerPrefs.GetInt("scenes");
        StartMenu();
        LevelLock();
        LevelOpen();
    }

    private void LevelLock()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }
    }

    private void LevelOpen()
    {
        for (int i = 0; i < _levelInLock; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    private void StartMenu()
    {
        Time.timeScale = 0;
    }

    private void OnOneLevel()
    {
        LoadLevel(2);
    }

    private void OnTwoLevel()
    {
        LoadLevel(3);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
