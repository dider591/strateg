using UnityEngine;
using DG.Tweening;

public class LinearColorChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Color _color;
    private float _duration = 1f;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = new Color(0.1886348f, 0.254717f, 0.2256408f);
        _meshRenderer.material.DOColor(_color, _duration).SetLoops(-1, LoopType.Yoyo);       
    }
}
