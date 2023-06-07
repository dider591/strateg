using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _mute;

    private bool _isMute;

    private void OnEnable()
    {
        _isMute = PlayerPrefs.GetInt("Mute") == 1;
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
        SceneManager.LoadScene(1);
    }

    private void OnMuteButtonClick()
    {
        _isMute = true;
        AudioListener.pause = _isMute;
        AudioListener.volume = _isMute ? 1 : 0;
        PlayerPrefs.SetInt("Mute", _isMute ? 1 : 0);
    }
}
