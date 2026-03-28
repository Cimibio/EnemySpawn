using UnityEngine;
using System;

public class EnemyFallDetector : MonoBehaviour
{
    [SerializeField] private float _fallThreshold = -1f;

    public event Action OnFall;

    private void Update()
    {
        if (transform.position.y < _fallThreshold)
        {
            OnFall?.Invoke();
        }
    }
}