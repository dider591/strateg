using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : Screen
{
    [SerializeField] private Button _oneLevel;
    [SerializeField] private Button _twoLevel;
    [SerializeField] private Button _threeLevel;
    [SerializeField] private Button _fourLevel;

    public UnityAction OneLevelButtonClick;
    public UnityAction TwoLevelButtonClick;
    public UnityAction ThreeLevelButtonClick;
    public UnityAction FourLevelButtonClick;

    private void OnEnable()
    {
        _oneLevel.onClick.AddListener(OnOneLevelButtonClick);
        _twoLevel.onClick.AddListener(OnTwoLevelButtonClick);
        _threeLevel.onClick.AddListener(OnThreeLevelButtonClick);
        _fourLevel.onClick.AddListener(OnFourLevelButtonClick);
    }

    private void OnDisable()
    {
        _oneLevel.onClick.RemoveListener(OnOneLevelButtonClick);
        _twoLevel.onClick.RemoveListener(OnTwoLevelButtonClick);
        _threeLevel.onClick.RemoveListener(OnThreeLevelButtonClick);
        _fourLevel.onClick.RemoveListener(OnFourLevelButtonClick);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _oneLevel.interactable = false;
    }

    public void OnOneLevelButtonClick()
    {
        OneLevelButtonClick?.Invoke();
    }

    public void OnTwoLevelButtonClick()
    {
        TwoLevelButtonClick?.Invoke();
    }

    public void OnThreeLevelButtonClick()
    {
        ThreeLevelButtonClick?.Invoke();
    }

    public void OnFourLevelButtonClick()
    {
        FourLevelButtonClick?.Invoke();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _oneLevel.interactable = true;
    }
}
