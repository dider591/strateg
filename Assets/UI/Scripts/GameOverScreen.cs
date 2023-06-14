using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class GameOverScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Image _imageReward;
    [SerializeField] private Text _maneyCount;

    private int _firstRrewardCountCoins = 200;
    private int _baseRewardCoins = 50;
    private int _activateRewardButtonTime = 300;
    private bool _isAddFirstReward = false;
    private int _mainMenuIndex = 2;

    private void OnEnable()
    {
        _player.ChangedManeyCount += OnChangedManeyCount;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
        _rewardButton.onClick.AddListener(OnRewardButtonClick);
    }

    private void OnDisable()
    {
        _player.ChangedManeyCount -= OnChangedManeyCount;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
        _rewardButton.onClick.AddListener(OnRewardButtonClick);
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _canvas.interactable = false;
        _canvas.blocksRaycasts = false;
    }

    public void OnRestartButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }

    private void OnRewardButtonClick()
    {
        _rewardButton.interactable = false;
        _imageReward.gameObject.SetActive(false);
        VideoAd.Show();

        if (_isAddFirstReward == false)
        {
            _player.AddManey(_firstRrewardCountCoins);
            _isAddFirstReward = true;
        }
        else
        {
            _player.AddManey(_baseRewardCoins);
        }

        Invoke(nameof(ActivateRewardButton), _activateRewardButtonTime);
    }

    private void ActivateRewardButton()
    {
        _rewardButton.interactable = true;
        _imageReward.gameObject.SetActive(true);
        _isAddFirstReward = false;
    }

    private void OnChangedManeyCount(int maneyCount)
    {
        _maneyCount.text = maneyCount.ToString();
    }
}
