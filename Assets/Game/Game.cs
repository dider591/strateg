using UnityEngine.SceneManagement;
using UnityEngine;
using Agava.WebUtility;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Screen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Mission[] _missions;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private SettingsScreen _settigsScreen;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delayStartInit;

    public event UnityAction<bool> StoppedGame;

    private bool _isAllInit;
    private bool _isStartMenu;
    private bool _isWin;
    private bool _isAllStartWaws;
    private bool _isNextMission = true;
    private bool _isUnlockLevel = false;
    private int _currentSceneIndex;
    private int _canvasMax = 1;
    private int _currentIndexMission = 0;
    private int _lastSceneIndex = 6;
    private string _scenes = "scenes";
    private string _ispause = "isPause";
    private float _runningValue = 1f;
    private float _stoppedValue = 0f;
    private float _delayAd = 1f;

    private void OnEnable()
    {

        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        foreach (var mission in _missions)
        {
            mission.Defeat += OnGameOver;
            mission.Win += OnWin;
        }
        InitMission();
        _winScreen.Close();
        _gameOverScreen.Close();
        _settigsScreen.Close();
        StartGame();
    }

    private void OnGameOver()
    {
        StoppedGame?.Invoke(true);
        _gameOverScreen.Open();
        GamePause.instance.SetPause(true);
    }

    private void OnWin()
    {
        if (_missions.Length > _currentIndexMission)
        {
            InitMission();
        }
        else
        {
            GamePause.instance.SetPause(true);
            UnLockLevel();
            _winScreen.Open();
        }
    }

    private void OnDisable()
    {
        foreach (var mission in _missions)
        {
            mission.Defeat -= OnGameOver;
            mission.Win -= OnWin;
        }
    }

    private void StartGame()
    {
        GamePause.instance.SetPause(false);

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
        if (_currentSceneIndex < _lastSceneIndex && _isUnlockLevel == false)
        {
            int countOpenLevel = PlayerPrefs.GetInt(_scenes) + 1;
            PlayerPrefs.SetInt(_scenes, countOpenLevel);
            _isUnlockLevel = true;
        }
    }

    private void InitMission()
    {
        _missions[_currentIndexMission].Init();
        _currentIndexMission++;
    }
}
