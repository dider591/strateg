using UnityEngine;
using Agava.WebUtility;

public class GamePause : MonoBehaviour
{
    public bool IsPause => _isPause;

    public static GamePause instance;

    private bool _isPause = true;

    private void Awake()
    {
        Debug.Log("GamePause._isPause = " + _isPause);
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
        if (_isPause == true)
        {
            return;
        }

        OnStopGame(inBackground);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (_isPause == true)
        {
            return;
        }

        OnStopGame(!hasFocus);
    }

    public void OnStopGame(bool isStopGame)
    {
        Time.timeScale = isStopGame ? 0 : 1;

        if (GameMute.instance.IsMute == true)
        {
            return;
        }

        GameMute.instance.SetVolume(isStopGame);
    }

    public void SetPause(bool pause)
    {
        _isPause = pause;
        OnStopGame(pause);
    }
}
