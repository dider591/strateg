using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System.Threading;

public class GameScreen : Screen
{
    [SerializeField] private Mission _mainTarget;
    [SerializeField] private Button _settigsButton;
    [SerializeField] private Button _machineGun;
    [SerializeField] private Button _zoomIn;
    [SerializeField] private Button _zoomOut;
    [SerializeField] private Button _missile;
    [SerializeField] private Button _squad;
    [SerializeField] private Button _artStrike;
    [SerializeField] private Screen _settigsScreen;
    [SerializeField] private Image _fillMissile;
    [SerializeField] private Image _fillMachineGun;
    [SerializeField] private Image _fillHealth;
    [SerializeField] private Image _fillSquads;
    [SerializeField] private Image _fillArtStrike;
    [SerializeField] private Player _player;
    [SerializeField] private Text _maneyCount;
    [SerializeField] private float _delayButtons;

    private float _delayMissile = 10f;
    private float _delayMachineGun = 5f;
    private float _delaySquad = 10f;
    private float _delayArtStrike = 10f;
    private float _healthChangeDurationn = 1f;
    private float _canvasAlphaMax = 1f;
    private float _canvasAlphaMin = 0f;
    private int _priceMessile = 100;
    private bool _isOpenSettings = false;
    private const string Mute = "Mute";

    private void Awake()
    {
        _maneyCount.text = _player.Maney.ToString();
        DeactivateButtons();
    }

    private void OnEnable()
    {
        Invoke(nameof(ActivateButtons), _delayButtons);
        _mainTarget.ProgressChanged += OnProgressChanged;
        _player.ChangedManeyCount += OnChangedManeyCount;
        _settigsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    private void OnDisable()
    {
        _mainTarget.ProgressChanged -= OnProgressChanged;
        _player.ChangedManeyCount -= OnChangedManeyCount;
        _settigsButton.onClick.RemoveListener(OnSettingsButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = _canvasAlphaMin;
        _settigsButton.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = _canvasAlphaMax;
        _settigsButton.interactable = true;
    }

    private void OnChangedManeyCount(int maneyCount)
    {
        _maneyCount.text = maneyCount.ToString();
    }

    private void OnProgressChanged(float health)
    {
        _fillHealth.DOFillAmount(health, _healthChangeDurationn);
    }

    private void OnSettingsButtonClick()
    {
        if (_isOpenSettings == false)
        {
            _settigsScreen.Open();
            _isOpenSettings = true;
        }
        else
        {
            _settigsScreen.Close();
            _isOpenSettings = false;
        }
    }

    private void DeactivateButtons()
    {
        _settigsButton.gameObject.SetActive(false);
        _machineGun.gameObject.SetActive(false);
        _missile.gameObject.SetActive(false);
        _squad.gameObject.SetActive(false);
        _artStrike.gameObject.SetActive(false);
        _zoomIn.gameObject.SetActive(false);
        _zoomOut.gameObject.SetActive(false);
    }

    private void ActivateButtons()
    {
        _settigsButton.gameObject.SetActive(true);
        _machineGun.gameObject.SetActive(true);
        _missile.gameObject.SetActive(true);
        _squad.gameObject.SetActive(true);
        _artStrike.gameObject.SetActive(true);
        _zoomIn.gameObject.SetActive(true);
        _zoomOut.gameObject.SetActive(true);
    }
}
