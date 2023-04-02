using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private Button[] _buttons;

    private int _countOpenScene = 1;

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
        Scene1.Load();
    }
    private void OnTwoLevel()
    {
        Scene2.Load();
    }

    public void OnSceneLoaded(LevelConfig argument)
    {
        _countOpenScene += argument.CountLevel;
    }
}
