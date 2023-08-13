using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class WinScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _maneyCount;

    private int _mainMenuIndex = 2;

    private void OnEnable()
    {
        _player.ChangedManeyCount += OnChangedManeyCount;
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _player.ChangedManeyCount -= OnChangedManeyCount;
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _canvas.blocksRaycasts = false;
        _canvas.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.blocksRaycasts = true;
        _canvas.interactable = true;
    }

    public void OnNextLevelButtonClick()
    {
        InterstitialAd.Show(null, OnCloseInterstitialAd);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }

    private void OnChangedManeyCount(int maneyCount)
    {
        _maneyCount.text = maneyCount.ToString();
    }

    private void OnCloseInterstitialAd(bool close)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (close == true)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
