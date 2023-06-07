using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _destroiTime = 1f;
    private void Start()
    {
        Invoke(nameof(Shutdown), _destroiTime);
    }

    private void Shutdown()
    {
        gameObject.SetActive(false);
    }
}
