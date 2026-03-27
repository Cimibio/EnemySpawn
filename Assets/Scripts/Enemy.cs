using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _fallThreshold = -1f;

    private Vector3 _moveDirection;

    public event Action<Enemy> Falled;

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime, Space.World);

        if (transform.position.y < _fallThreshold)
            Falled?.Invoke(this);
    }

    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _moveDirection = direction.normalized;
    }
}
