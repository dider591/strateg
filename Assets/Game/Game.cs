using UnityEngine.SceneManagement;
using UnityEngine;
using Agava.YandexGames;
using Agava.WebUtility;

public class Game : MonoBehaviour
{
    [SerializeField] private Screen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Mission[] _missions;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private SettingsScreen _settigsScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delayStartInit;

    private bool _isAllInit;
    private bool _isStartMenu;
    private bool _isWin;
    private bool _isAllStartWaws;
    private bool _isNextMission = true;
    private int _currentLevel;
    private int _canvasMax = 1;
    private int _currentIndexMission = 0;
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
        foreach (var mission in _missions)
        {
            mission.Defeat += OnGameOver;
            mission.Win += OnWin;
        }
        InitMission();

        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnWin()
    {
        if (_missions.Length > _currentIndexMission)
        {
            InitMission();
        }
        else
        {
            InterstitialAd.Show();
            UnLockLevel();
            _winScreen.Open();
            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        foreach (var mission in _missions)
        {
            mission.Defeat -= OnGameOver;
            mission.Win -= OnWin;
        }
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

    private void InitMission()
    {
        _missions[_currentIndexMission].Init();
        _currentIndexMission++;
    }
}
