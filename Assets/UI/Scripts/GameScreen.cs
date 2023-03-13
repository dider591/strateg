using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;

public class GameScreen : Screen
{
    [SerializeField] private HelicopterMain _helicopterMain;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _machineGun;
    [SerializeField] private Button _zoomIn;
    [SerializeField] private Button _zoomOut;
    [SerializeField] private Button _missile;
    [SerializeField] private Button _squad;
    [SerializeField] private Button _artStrike;
    [SerializeField] private Image _fillMissile;
    [SerializeField] private Image _fillMachineGun;
    [SerializeField] private Image _fillHealth;
    [SerializeField] private Image _fillSquads;
    [SerializeField] private Image _fillArtStrike;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _maneyCount;

    //public UnityAction MenuButtonClick;
    //public UnityAction MachineGunButtonClick;
    //public UnityAction MessileButtonClick;
    //public UnityAction SquadButtonClick;
    //public UnityAction ArtStrskeButtonClick;

    private float _delayMissile = 10f;
    private float _delayMachineGun = 5f;
    private float _delaySquad = 10f;
    private float _delayArtStrike = 10f;
    private float _delayButtons = 9f;
    private float _healthChangeDurationn = 1f;
    //private float _fillAmountMax = 1f;
    //private float _fillAmountMin = 0f;
    private float _canvasAlphaMax = 1f;
    private float _canvasAlphaMin = 0f;
    private int _priceMessile = 100;

    private void Awake()
    {
        DeactivateButtons();
    }

    private void OnEnable()
    {
        Invoke(nameof(ActivateButtons), _delayButtons);
        _helicopterMain.HealthChanged += OnHealthChanged;
        //_menuButton.onClick.AddListener(OnMenuButtonClick);
        //_machineGun.onClick.AddListener(OnMachineGunButtonClick);
        //_missile.onClick.AddListener(OnMessileButtonClick);
        //_squad.onClick.AddListener(OnSquadsButtonClick);
        //_artStrike.onClick.AddListener(OnArtStrikeButtonClick);
        _player.ChangedManeyCount += OnChangedManeyCount;
    }

    private void OnDisable()
    {
        _helicopterMain.HealthChanged -= OnHealthChanged;
        //_menuButton.onClick.RemoveListener(OnMenuButtonClick);
        //_machineGun.onClick.RemoveListener(OnMachineGunButtonClick);
        //_missile.onClick.RemoveListener(OnMessileButtonClick);
        //_squad.onClick.RemoveListener(OnSquadsButtonClick);
        //_artStrike.onClick.RemoveListener(OnArtStrikeButtonClick);
        _player.ChangedManeyCount -= OnChangedManeyCount;
    }

    public override void Close()
    {
        _canvas.alpha = _canvasAlphaMin;
        _menuButton.interactable = false;
    }

    public override void Open()
    {
        _canvas.alpha = _canvasAlphaMax;
        _menuButton.interactable = true;
    }

    //public void OnMenuButtonClick()
    //{
    //    MenuButtonClick?.Invoke();
    //}

    //public void OnMachineGunButtonClick()
    //{
    //    MachineGunButtonClick?.Invoke();
    //    Recharges(_fillMachineGun, _delayMachineGun);
    //    StartCoroutine(BlocksButton(_machineGun, _delayMachineGun));
    //}

    //public void OnMessileButtonClick()
    //{
    //    if (_player.Maney > _priceMessile)
    //    {
    //        MessileButtonClick?.Invoke();
    //        Recharges(_fillMissile, _delayMissile);
    //        StartCoroutine(BlocksButton(_missile, _delayMissile));
    //        _player.ReducesManey(_priceMessile);
    //    }
    //}
    private void OnChangedManeyCount(int maneyCount)
    {
        _maneyCount.text = maneyCount.ToString();
    }

    //private void OnArtStrikeButtonClick()
    //{
    //    ArtStrskeButtonClick?.Invoke();
    //    Recharges(_fillArtStrike, _delayArtStrike);
    //    StartCoroutine(BlocksButton(_artStrike, _delayArtStrike));
    //}

    //private void OnSquadsButtonClick()
    //{
    //    SquadButtonClick?.Invoke();
    //    Recharges(_fillSquads, _delaySquad);
    //    StartCoroutine(BlocksButton(_squad, _delaySquad));
    //}

    //private void Recharges(Image image, float delay)
    //{
    //    image.fillAmount = _fillAmountMax;
    //    image.DOFillAmount(_fillAmountMin, delay);
    //}

    //private IEnumerator BlocksButton(Button button, float delay)
    //{
    //    button.interactable = false;
    //    yield return new WaitForSeconds(delay);
    //    button.interactable = true;
    //}

    //private void DeactivatesButtons(Image image, Button button)
    //{
    //    image.fillAmount = _fillAmountMax;
    //    button.interactable = false;
    //}

    //private void ActivateButton(Image image, Button button, float delay)
    //{
    //    Recharges(image, delay);
    //    StartCoroutine(BlocksButton(button, delay));
    //}

    private void OnHealthChanged(float health)
    {
        _fillHealth.DOFillAmount(health, _healthChangeDurationn);
    }

    private void DeactivateButtons()
    {
        _menuButton.gameObject.SetActive(false);
        _machineGun.gameObject.SetActive(false);
        _missile.gameObject.SetActive(false);
        _squad.gameObject.SetActive(false);
        _artStrike.gameObject.SetActive(false);
        _zoomIn.gameObject.SetActive(false);
        _zoomOut.gameObject.SetActive(false);
    }

    private void ActivateButtons()
    {
        _menuButton.gameObject.SetActive(true);
        _machineGun.gameObject.SetActive(true);
        _missile.gameObject.SetActive(true);
        _squad.gameObject.SetActive(true);
        _artStrike.gameObject.SetActive(true);
        _zoomIn.gameObject.SetActive(true);
        _zoomOut.gameObject.SetActive(true);
    }
}
