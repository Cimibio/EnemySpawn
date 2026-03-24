using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _fallThreshold = -1f;

    public event Action<Enemy> Falled;

    public void Init(Vector3 position, Quaternion direction)
    {
        transform.position = position;
        transform.rotation = direction;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (transform.position.y < _fallThreshold)
            Falled?.Invoke(this);
    }
}
