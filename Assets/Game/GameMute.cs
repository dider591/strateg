using UnityEngine;

public class GameMute : MonoBehaviour
{
    public bool IsMute => _isMute;

    public static GameMute instance;

    private bool _isMute = false;


    private void Awake()
    {
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

    public void SetVolume(bool isMute)
    {
        AudioListener.pause = isMute;
        AudioListener.volume = isMute ? 0 : 1;
        Debug.Log("_isMute = " + _isMute);
    }

    public void Mute()
    {
        _isMute = !_isMute;
        SetVolume(_isMute);
    }
}
