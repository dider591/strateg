using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _maneyCount;

    private int _nextScene = 4;
    private int _mainMenu = 1;

    private void OnEnable()
    {
        _player.ChangedManeyCount += OnChangedManeyCount;
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _player.ChangedManeyCount -= OnChangedManeyCount;
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _canvas.blocksRaycasts = false;
        _canvas.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.blocksRaycasts = true;
        _canvas.interactable = true;
    }

    public void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void OnSelectButtonClick()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    private void OnChangedManeyCount(int maneyCount)
    {
        _maneyCount.text = maneyCount.ToString();
    }
}
