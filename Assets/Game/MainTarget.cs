using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MainTarget : MonoBehaviour
{
    [SerializeField] protected TaskMessageScreen _taskMessage;

    public UnityAction<float> ProgressChanged;
    public UnityAction Win;
    public UnityAction Defeat;
}