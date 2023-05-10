using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private float _delay;
    [SerializeField] private int _price;
    [SerializeField] private Text _priceText;

    private float _fillAmountMax = 1f;
    private float _fillAmountMin = 0f;
    private Player _player;
    private Button _button;
    private bool _isActive;
    private Color _activateColor;
    private Color _deactivateColor = new(0, 0, 0, 0.7f);

    private void Awake()
    {
        _button = GetComponent<Button>();
        _player = FindObjectOfType<Player>();
        _activateColor = _fillImage.color;

        if (_price > 0)
        {
            _priceText.text = _price.ToString();
        }
    }

    private void Update()
    {
        if (_price > 0)
        {
            if (_player.Maney >= _price && _isActive == false)
            {
                ActivateButton(_fillImage, _button);
            }
            if (_player.Maney < _price)
            {
                DeactivateButton(_fillImage, _button);
            }
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void ActivateButton(Image image, Button button)
    {
        _isActive = true;
        image.fillAmount = _fillAmountMin;
        image.color = _activateColor;
        button.interactable = true;
    }

    private void DeactivateButton(Image image, Button button)
    {
        _isActive = false;
        image.fillAmount = _fillAmountMax;
        image.color = _deactivateColor;
        button.interactable = false;
    }

    private void OnButtonClick()
    {
        if (_price > 0)
        {
            _player.ReducesManey(_price);
        }

        Recharges(_fillImage, _delay);
        StartCoroutine(BlocksButton(_button, _delay));
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
}
