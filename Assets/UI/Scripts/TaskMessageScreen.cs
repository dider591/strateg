using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMessageScreen : Screen
{
    private Text _text;
    private float _timeClose = 4f;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public override void Open()
    {
        _canvas.alpha = 1;
        _canvas.interactable = true;
        Invoke(nameof(Close), _timeClose);
    }

    public override void Close()
    {
        _canvas.alpha = 0;
        _canvas.interactable = false;
    }
}
