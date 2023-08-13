using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Advertising : MonoBehaviour
{
    public event UnityAction PauseOn;
    public event UnityAction PauseOff;

    private void ShowAd()
    {
        InterstitialAd.Show(OnOpenAd, OnCloseAd);
    }

    private void OnOpenAd()
    {
        Time.timeScale = 0;
        PauseOn?.Invoke();
    }

    private void OnCloseAd(bool close)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (close == true)
        {
            PauseOff?.Invoke();
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
