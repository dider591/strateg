using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LocalizationScreen : Screen
{
    [SerializeField] private Button _englishButton;
    [SerializeField] private Button _rissianButton;
    [SerializeField] private Button _turkishButton;

    private const string Language = "language";

    private string _russian = "russian";
    private string _turkish = "turkish";
    private string _english = "english";

    public UnityAction ChangeLanguage;

    private void Awake()
    {
        Close();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _englishButton.onClick.AddListener(OnEnglishButtonClick);
        _rissianButton.onClick.AddListener(OnRussianButtonClick);
        _turkishButton.onClick.AddListener(OnTurkishButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _englishButton.onClick.RemoveListener(OnEnglishButtonClick);
        _rissianButton.onClick.RemoveListener(OnRussianButtonClick);
        _turkishButton.onClick.RemoveListener(OnTurkishButtonClick);
    }

    private void OnEnglishButtonClick()
    {
        SetLanguage(_english);
        Close();
    }

    private void OnRussianButtonClick()
    {
        SetLanguage(_russian);
        Close();
    }

    private void OnTurkishButtonClick()
    {
        SetLanguage(_turkish);
        Close();
    }

    private void SetLanguage(string language)
    {
        PlayerPrefs.SetString(Language, language);
        ChangeLanguage?.Invoke();
    }
}
