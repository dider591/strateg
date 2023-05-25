using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image Image;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private bool _isChange = false;

    private void OnEnable()
    {
        button.onClick.AddListener(OnChangeImage);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnChangeImage);
    }

    private void OnChangeImage()
    {
        if (_isChange == false)
        {
            Image.sprite = _offSprite;
            _isChange = true;
        }
        else
        {
            Image.sprite = _onSprite;
            _isChange = false;
        }
    }
}
