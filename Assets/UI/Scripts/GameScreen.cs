using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class GameScreen : Screen
{
    [SerializeField] private HelicopterMain _helicopterMain;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _machineGun;
    [SerializeField] private Button _zoomIn;
    [SerializeField] private Button _zoomOut;
    [SerializeField] private Button _missile;
    [SerializeField] private Image _fillMissile;
    [SerializeField] private Image _fillMachineGun;
    [SerializeField] private Image _fillHealth;

    public UnityAction MenuButtonClick;
    public UnityAction MachineGunButtonClick;
    public UnityAction MessileButtonClick;

    private float _delayMissile = 10f;
    private float _delayMachineGun = 5f;
    private float _delayButtons = 9f;
    private float _healthChangeDurationn = 1f;
    private float _fillAmountMax = 1f;
    private float _fillAmountMin = 0f;
    private float _canvasAlphaMax = 1f;
    private float _canvasAlphaMin = 0f;

    private void Awake()
    {
        DeactivateButtons();
    }

    private void OnEnable()
    {
        Invoke(nameof(ActivateButtons), _delayButtons);
        _helicopterMain.HealthChanged += OnHealthChanged;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _machineGun.onClick.AddListener(OnMachineGunButtonClick);
        _missile.onClick.AddListener(OnMessileButtonClick);
    }

    private void OnDisable()
    {
        _helicopterMain.HealthChanged -= OnHealthChanged;
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _machineGun.onClick.RemoveListener(OnMachineGunButtonClick);
        _missile.onClick.RemoveListener(OnMessileButtonClick);
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

    public void OnMenuButtonClick()
    {
        MenuButtonClick?.Invoke();
    }

    public void OnMachineGunButtonClick()
    {
        MachineGunButtonClick?.Invoke();
        Recharges(_fillMachineGun, _delayMachineGun);
        StartCoroutine(BlocksButton(_machineGun, _delayMachineGun));
    }

    public void OnMessileButtonClick()
    {
        MessileButtonClick?.Invoke();
        Recharges(_fillMissile, _delayMissile);
        StartCoroutine(BlocksButton(_missile, _delayMissile));
    }

    private void Recharges(Image image, float delay)
    {
        image.fillAmount = _fillAmountMax;
        image.DOFillAmount(_fillAmountMin, delay);
    }

    private IEnumerator BlocksButton(Button button, float delay)
    {
        button.interactable = false;
        yield return new WaitForSeconds(delay);
        button.interactable = true;
    }

    private void OnHealthChanged(float health)
    {
        _fillHealth.DOFillAmount(health, _healthChangeDurationn);
    }

    private void DeactivateButtons()
    {
        _menuButton.gameObject.SetActive(false);
        _machineGun.gameObject.SetActive(false);
        _missile.gameObject.SetActive(false);
        _zoomIn.gameObject.SetActive(false);
        _zoomOut.gameObject.SetActive(false);
    }

    private void ActivateButtons()
    {
        _menuButton.gameObject.SetActive(true);
        _machineGun.gameObject.SetActive(true);
        _missile.gameObject.SetActive(true);
        _zoomIn.gameObject.SetActive(true);
        _zoomOut.gameObject.SetActive(true);
    }
}
