using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private Screen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private MainTarget _mainTarget;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private Button _menuButton;
    [SerializeField] private float _delayStart;

    private bool _isAllInit;
    private bool _isStartMenu;
    private int _currentLevel;
    private int _currentWave;
    private int _canvasMax = 1;

    private enum GameMode
    {
        Assault,
        Defense
    }

    private void OnEnable()
    {
        StartGame();
        _winScreen.Close();
        _gameOverScreen.Close();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("levels", _currentLevel);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _mainTarget.GameOver += OnGameOver;
        _mainTarget.Healed += OnHealed;
    }

    private void OnGameOver()
    {
        if (_gameMode == GameMode.Defense)
        {
            _gameOverScreen.Open();
            Time.timeScale = 0;
        }
        if (_gameMode == GameMode.Assault)
        {
            Init();
        }
    }

    private void OnHealed()
    {
        if (_gameMode == GameMode.Defense)
        {
            _winScreen.Open();
            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _mainTarget.GameOver -= OnGameOver;
    }

    private void OnMenuButtonClick()
    {
        _gameScreen.Close();
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _currentWave = 1;

        if (!_isAllInit && _gameMode == GameMode.Defense)
        {
            _isAllInit = true;
            Invoke(nameof(Init), _delayStart);
        }
    }

    private void Init()
    {
        foreach (var spawner in _spawners)
        {
            spawner.SetReady(true);
        }
    }

    private void UnLockLevel()
    {
        if (_currentLevel >= PlayerPrefs.GetInt("levels")) ;
        {
            PlayerPrefs.SetInt("levels", _currentLevel + 1);
        }
    }
}
