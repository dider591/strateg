using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvas;

    public abstract void Open();

    public abstract void Close();
}
