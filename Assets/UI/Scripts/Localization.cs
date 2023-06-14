using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    [SerializeField] private Button _englishButton;
    [SerializeField] private Button _rissianButton;
    [SerializeField] private Button _turkishButton;

    private const string Language = "language";

    private string _russian = "russian";
    private string _turkish = "turkish";
    private string _english = "english";
    private int _mainMenuIndex = 2;

    private void OnEnable()
    {
        InterstitialAd.Show();
        _englishButton.onClick.AddListener(OnEnglishButtonClick);
        _rissianButton.onClick.AddListener(OnRussianButtonClick);
        _turkishButton.onClick.AddListener(OnTurkishButtonClick);
    }

    private void OnDisable()
    {
        _englishButton.onClick.RemoveListener(OnEnglishButtonClick);
        _rissianButton.onClick.RemoveListener(OnRussianButtonClick);
        _turkishButton.onClick.RemoveListener(OnTurkishButtonClick);
    }

    private void OnEnglishButtonClick()
    {
        SetLanguage(_english);
        LoadLevel();
    }

    private void OnRussianButtonClick()
    {
        SetLanguage(_russian);
        LoadLevel();
    }

    private void OnTurkishButtonClick()
    {
        SetLanguage(_turkish);
        LoadLevel();
    }

    private void SetLanguage(string language)
    {
        PlayerPrefs.SetString(Language, language);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }
}
