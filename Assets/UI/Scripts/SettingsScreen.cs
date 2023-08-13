using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _mute;

    private int _mainMenuIndex = 2;

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

        GamePause.instance.SetPause(false);
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _mainMenu.interactable = true;
        _mute.interactable = true;
        GamePause.instance.SetPause(true);
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }

    private void OnMuteButtonClick()
    {
        GameMute.instance.Mute();

        //_isMute = PlayerPrefs.GetInt(Mute) == 1;
        //_isMute = !_isMute;

        //PlayerPrefs.SetInt(Mute, _isMute ? 1 : 0);
        //AudioListener.volume = _isMute ? 0 : 1;
        //AudioListener.pause = _isMute;
        //Debug.Log("Mute = " + _isMute);
    }
}
