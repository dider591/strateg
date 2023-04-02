using System;
using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private LevelConfig _gameOverConfig;
    [SerializeField] private LevelConfig _winConfig;
    [SerializeField] private MainTarget _mainTarget;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private Button _menuButton;
    [SerializeField] private float _delayStart;

    //private bool _isCrashed;
    private bool _isAllInit;
    private bool _isStartMenu;

    private void OnEnable()
    {
        StartGame();
        //_FallenHelicopter.Crashed += OnHelicopterCrash;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _mainTarget.GameOver += OnGameOver;
        _mainTarget.Healed += OnHealed;
    }

    private void OnHealed()
    {
        if (_isStartMenu == false)
        {
            _isStartMenu = true;
            Menu.Load(_winConfig);
        }
    }

    private void OnDisable()
    {
        //_FallenHelicopter.Crashed -= OnHelicopterCrash;
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _mainTarget.GameOver -= OnGameOver;
    }

    private void Update()
    {
        if (/*_isCrashed && */_isAllInit == false)
        {
            InitSpawners();
        }
    }

    private void OnMenuButtonClick()
    {
        _gameScreen.Close();
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        if (/*_isCrashed && */_isAllInit == false)
        {
            _isAllInit = true;
            Invoke(nameof(InitSpawners), _delayStart);
        }
    }

    private void OnGameOver()
    {
        GameOver.Load();
        Time.timeScale = 0;
    }

    //private void OnHelicopterCrash()
    //{
    //    _isCrashed = true;
    //}

    private void InitSpawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.SetReady(true);
        }
    }
}
