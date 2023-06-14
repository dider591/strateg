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
    private int _currentOpenLevels = 1;
    private int _oneLevelIndex = 3;
    private int _twolevelIndex = 4;
    private string _scenes = "scenes";

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
        PlayerPrefs.SetInt(_scenes, _currentOpenLevels);
        _levelInLock = PlayerPrefs.GetInt(_scenes);
        StartMenu();
        LevelLock();
        LevelOpen();
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
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
        LoadLevel(_oneLevelIndex);
    }

    private void OnTwoLevel()
    {
        LoadLevel(_twolevelIndex);
    }

}
