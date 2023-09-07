using UnityEngine;
using Agava.WebUtility;

public class GamePause : MonoBehaviour
{
    private bool _isPause = true;
    private bool _isFocus = true;
    private bool _isInBackground = false;

    public static GamePause instance;


    private void Awake()
    {
        WebApplication.InBackgroundChangeEvent += OnBackgroundChangeEvent;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnBackgroundChangeEvent;
    }

    private void OnBackgroundChangeEvent(bool inBackground)
    {
        if (_isPause == false && _isFocus == true)
        {
            _isInBackground = inBackground;
            OnStopGame(inBackground);
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (_isPause == false && _isInBackground == false)
        {
            _isFocus = hasFocus;
            OnStopGame(!hasFocus);
        }
    }

    public void OnStopGame(bool isStopGame)
    {
        Time.timeScale = isStopGame ? 0 : 1;

        if (GameMute.instance.IsMute == false)
        {
            GameMute.instance.SetVolume(isStopGame);
        }
    }

    public void SetPause(bool pause)
    {
        _isPause = pause;
        OnStopGame(pause);
    }
}
