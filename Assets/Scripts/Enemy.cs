using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyFallDetector))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private EnemyFallDetector _fallDetector;

    public event Action<Enemy> Falled;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _fallDetector = GetComponent<EnemyFallDetector>();

        _fallDetector.OnFall += HandleFall;
    }

    private void OnDestroy()
    {
        if (_fallDetector != null)
            _fallDetector.OnFall -= HandleFall;
    }

    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _enemyMover.SetDirection(direction);
    }

    private void HandleFall()
    {
        Falled?.Invoke(this);
    }
}