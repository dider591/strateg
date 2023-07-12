using UnityEngine;

public class StartMenuScreen : MonoBehaviour
{
    [SerializeField] private StartMenu _startMenuNew;
    [SerializeField] private StartMenu _startMenuContinue;

    private string _scenes = "scenes";
    private int _currentOpenLevels;

    private void Awake()
    {
        _startMenuNew.gameObject.SetActive(false);
        _startMenuContinue.gameObject.SetActive(false);

        _currentOpenLevels = PlayerPrefs.GetInt(_scenes);

        if (_currentOpenLevels > 0)
        {
            _startMenuContinue.gameObject.SetActive(true);
        }
        else
        {
            _startMenuNew.gameObject.SetActive(true);
        }
    }
}
