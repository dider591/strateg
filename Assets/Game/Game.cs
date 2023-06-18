using UnityEngine.SceneManagement;
using UnityEngine;
using Agava.YandexGames;
using Agava.WebUtility;

public class Game : MonoBehaviour
{
    [SerializeField] private Screen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private MainTarget _mainTarget;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private SettingsScreen _settigsScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delayStartInit;

    private bool _isAllInit;
    private bool _isStartMenu;
    private bool _isWin;
    private bool _isAllStartWaws;
    private int _currentLevel;
    private int _canvasMax = 1;
    private string _scenes = "scenes";
    private float _runningValue = 1f;
    private float _stoppedValue = 0f;

    private void OnEnable()
    {
        StartGame();
        _winScreen.Close();
        _gameOverScreen.Close();
        _settigsScreen.Close();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _mainTarget.Defeat += OnGameOver;
        _mainTarget.Win += OnWin;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnWin()
    {
        InterstitialAd.Show();
        UnLockLevel();
        _winScreen.Open();
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _mainTarget.Defeat -= OnGameOver;
        _mainTarget.Win -= OnWin;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnMenuButtonClick()
    {
        _gameScreen.Close();
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        if (!_isAllInit)
        {
            _isAllInit = true;
            Invoke(nameof(Init), _delayStartInit);
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
        if (_currentLevel >= PlayerPrefs.GetInt(_scenes)) ;
        {
            PlayerPrefs.SetInt(_scenes, _currentLevel + 1);
        }
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? _stoppedValue : _runningValue;
        Time.timeScale = inBackground ? _stoppedValue : _runningValue;
    }
}
