using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _mute;

    private const string Mute = "Mute";
    private int _mainMenuIndex = 2;
    private bool _isMute;

    private void OnEnable()
    {
        _mainMenu.onClick.AddListener(OnMainMenuButtonClick);
        _mute.onClick.AddListener(OnMuteButtonClick);
    }

    private void OnDisable()
    {
        _mainMenu.onClick.RemoveListener(OnMainMenuButtonClick);
        _mute.onClick.RemoveListener(OnMuteButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _mainMenu.interactable = false;
        _mute.interactable = false;
        Time.timeScale = 1;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _mainMenu.interactable = true;
        _mute.interactable = true;
        Time.timeScale = 0;
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }

    private void OnMuteButtonClick()
    {
        _isMute = PlayerPrefs.GetInt(Mute) == 1;
        _isMute = !_isMute;
        
        PlayerPrefs.SetInt(Mute, _isMute ? 1 : 0);
        AudioListener.volume = _isMute ? 0 : 1;
        AudioListener.pause = _isMute;
    }
}
