using UnityEngine;
using UnityEngine.Events;

public abstract class Mission : MonoBehaviour
{
    [SerializeField] protected TaskMessageScreen _taskMessage;

    public UnityAction<float> ProgressChanged;
    public UnityAction Win;
    public UnityAction Defeat;

    protected bool _isWin = false;

    public abstract void Init();
}
