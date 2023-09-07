using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using System;

public class WinScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _maneyCount;

    private int _mainMenuIndex = 2;
    private bool _isOpenAd = false;

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
        ShowAd();     
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
        Debug.Log("CloseAd = " + close);
        LoadNextLevel();
    }

    private void OnOfflineInterstitialAd()
    {
        Debug.Log("AdOffline");
        LoadNextLevel();
    }

    private void OnErrorInterstitialAd(string errorMessage)
    {
        Debug.Log(errorMessage);
        LoadNextLevel();
    }

    private void ShowAd()
    {
        InterstitialAd.Show(null, OnCloseInterstitialAd, OnErrorInterstitialAd, OnOfflineInterstitialAd);
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
