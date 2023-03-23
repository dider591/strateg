using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _destroiTime = 1f;
    private void Start()
    {
        Destroy(gameObject, _destroiTime);
    }
}
