using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLastScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Text _maneyCount;

    private int _mainMenu = 2;

    private void OnEnable()
    {
        _player.ChangedManeyCount += OnChangedManeyCount;
        _mainMenuButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnDisable()
    {
        _player.ChangedManeyCount += OnChangedManeyCount;
        _mainMenuButton.onClick.RemoveListener(OnSelectButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _canvas.interactable = false;
        _canvas.blocksRaycasts = false;
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
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
