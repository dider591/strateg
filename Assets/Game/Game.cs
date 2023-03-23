using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private FallenHelicopter _FallenHelicopter;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private Button _menuButton;

    private const string SampleScene = "SampleScene";

    private bool _isCrashed;
    private bool _isAllInit;

    private void OnEnable()
    {
        _FallenHelicopter.Crashed += OnHelicopterCrash;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick += OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick += OnExitButtonClick;
        //_gameScreen.MenuButtonClick += OnMenuButtonClick;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _FallenHelicopter.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _FallenHelicopter.Crashed -= OnHelicopterCrash;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick -= OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick -= OnExitButtonClick;
        //_gameScreen.MenuButtonClick -= OnMenuButtonClick;
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _FallenHelicopter.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _gameOverScreen.Close();
        _gameScreen.Close();
    }

    private void Update()
    {
        if (_isCrashed && _isAllInit == false)
        {
            InitSpawners();
        }
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _gameOverScreen.Close();
        _gameScreen.Open();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SampleScene);
        _gameOverScreen.Close();
        _gameScreen.Open();
        StartGame();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnMenuButtonClick()
    {
        _gameScreen.Close();
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        _gameScreen.Close();
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnHelicopterCrash()
    {
        _isCrashed = true;
    }

    private void InitSpawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.SetReady(true);
        }

        _isAllInit = true;
    }
}
