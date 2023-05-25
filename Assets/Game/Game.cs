using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Screen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private MainTarget _mainTarget;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private SettingsScreen _settigsScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delayStart;

    private bool _isAllInit;
    private bool _isStartMenu;
    private bool _isWin;
    private int _currentLevel;
    private int _currentWave;
    private int _canvasMax = 1;

    private void OnEnable()
    {
        StartGame();
        _winScreen.Close();
        _gameOverScreen.Close();
        _settigsScreen.Close();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _mainTarget.Defeat += OnGameOver;
        _mainTarget.Win += OnWin;
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnWin()
    {
        UnLockLevel();
        _winScreen.Open();
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _mainTarget.Defeat -= OnGameOver;
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

        if (!_isAllInit)
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
        if (_currentLevel >= PlayerPrefs.GetInt("scenes")) ;
        {
            PlayerPrefs.SetInt("scenes", _currentLevel + 1);
        }
    }
}
