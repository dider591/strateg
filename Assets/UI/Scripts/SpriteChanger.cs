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

        if (GameMute.instance.IsMute == true)
        {
            SetImage(_offSprite);
            _isChange = true;
        }
        else
        {
            SetImage(_onSprite);
            _isChange = false;
        }
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnChangeImage);
    }

    private void OnChangeImage()
    {
        if (_isChange == false)
        {
            SetImage(_offSprite);
            _isChange = true;
        }
        else
        {
            SetImage(_onSprite);
            _isChange = false;
        }
    }

    private void SetImage(Sprite image)
    {
        Image.sprite = image;
    }
}
