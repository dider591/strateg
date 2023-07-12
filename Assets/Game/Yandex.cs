#pragma warning disable
using UnityEngine.SceneManagement;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;


public class Yandex : MonoBehaviour
{
    public static Yandex Instance;
    private int _startSceneIndex = 1;
    private const string Language = "language";

    private const string Russian = "russian";
    private const string Turkish = "turkish";
    private const string English = "english";

    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    private string _languageCode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        if (YandexGamesSdk.IsInitialized)

        _languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (_languageCode)
        {
            case EnglishCode:
                SetLanguage(English);
                break;
            case RussianCode:
                SetLanguage(Russian);
                break;
            case TurkishCode:
                SetLanguage(Turkish);
                break;
            default:
                SetLanguage(English);
                break;
        }

        SceneManager.LoadScene(_startSceneIndex);
    }

    private void SetLanguage(string language)
    {
        PlayerPrefs.SetString(Language, language);
    }
}