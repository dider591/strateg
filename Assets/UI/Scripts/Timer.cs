using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private int _delta;
    [SerializeField] private int _secunds;
    [SerializeField] private int _minutes;

    public event UnityAction TimesUp;

    private void Start()
    {
        StartCoroutine(StartTime());
    }

    private void Update()
    {
        if (_minutes == 0 && _secunds <= 1)
        {
            TimesUp?.Invoke();
        }
    }

    private IEnumerator StartTime()
    {
        while (true)
        {
            if (_secunds == 0)
            {
                _minutes--;
                _secunds = 59;
            }

            _secunds -= _delta;
            _text.text = _minutes.ToString() + " : " + _secunds.ToString();
            yield return new WaitForSeconds(_delta);
        }
    }
}
