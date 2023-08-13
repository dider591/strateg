using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvas;

    public abstract void Open();

    public abstract void Close();
}
