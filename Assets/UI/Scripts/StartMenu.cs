using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _selectlanguageButton;
    [SerializeField] private LocalizationScreen _selectLanguageScreen;

    private int _currentOpenLevels = 0;
    private string _scenes = "scenes";
    private string Mute = "Mute";
    private string _score = "_score";
    private int _mainMenuIndex = 2;
    private float _delayAd = 1f;

    private void OnEnable()
    {
        InterstitialAd.Show();
        _startButton.onClick.AddListener(OnPlayButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _selectlanguageButton.onClick.AddListener(OnSelectLanguageButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnPlayButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _selectlanguageButton.onClick.RemoveListener(OnSelectLanguageButtonClick);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }

    private void OnPlayButtonClick()
    {
        PlayerPrefs.DeleteKey(_score);
        PlayerPrefs.SetInt(_scenes, _currentOpenLevels);
        PlayerPrefs.SetInt(Mute, 0);

        LoadMainMenu();
    }

    private void OnContinueButtonClick()
    {
        LoadMainMenu();
    }

    private void OnSelectLanguageButtonClick()
    {
        _selectLanguageScreen.Open();
    }
}
