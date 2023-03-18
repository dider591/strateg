using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Helicopter _helicopterMain;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Button _menuButton;

    private const string SampleScene = "SampleScene";

    private float _wavs;
    protected Vector3 _crashedPoint;
    //private bool _isCrashed;
    //private bool _isAllInit;

    private void OnEnable()
    {
        //_helicopterMain.CrashedPoint += OnHelicopterCrash;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick += OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick += OnExitButtonClick;
        //_gameScreen.MenuButtonClick += OnMenuButtonClick;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _helicopterMain.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        //_helicopterMain.CrashedPoint -= OnHelicopterCrash;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick -= OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick -= OnExitButtonClick;
        //_gameScreen.MenuButtonClick -= OnMenuButtonClick;
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _helicopterMain.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _gameOverScreen.Close();
        _gameScreen.Close();
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
}
