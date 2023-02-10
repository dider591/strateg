using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private HelicopterMain _helicopterMain;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameScreen _gameScreen;

    private const string SampleScene = "SampleScene";

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick += OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick += OnExitButtonClick;
        _gameScreen.MenuButtonClick += OnMenuButtonClick;
        _helicopterMain.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.CloseButtonClick -= OnPlayButtonClick;
        _gameOverScreen.ExitButtonClick -= OnExitButtonClick;
        _gameScreen.MenuButtonClick -= OnMenuButtonClick;
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
