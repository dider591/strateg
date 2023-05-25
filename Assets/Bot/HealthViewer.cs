using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class HealthViewer : MonoBehaviour, ISelectable
{
    [SerializeField] private Slider _slider;

    private TargetHeathView _targetLookPoint;
    private CanvasGroup _canvasGroup;
    private float _maxActivCanvas = 1f;
    private float _minActivCanvas = 0.2f;
    private bool _died = false;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = _minActivCanvas;
        _targetLookPoint = FindObjectOfType<TargetHeathView>();
    }

    private void Update()
    {
        transform.LookAt(_targetLookPoint.transform.position);
    }

    public void SetSizeHealth(int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }

    public void HealthChange(int health)
    {
        _slider.value = health;

        if (_slider.value <= 0)
        {
            _canvasGroup.alpha = 0;
            _died = true;
        }
    }

    public void Select()
    {
        if (_canvasGroup != null)
        {
            if (_died == false)
            {
                _canvasGroup.alpha = _maxActivCanvas;
            }
        }
    }

    public void Deselect()
    {
        if (_canvasGroup != null)
        {
            if (_died == false)
            {
                _canvasGroup.alpha = _minActivCanvas;
            }
        }
    }
}
