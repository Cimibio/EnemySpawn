using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Vector3 _currentDirection;

    public void SetDirection(Vector3 direction)
    {
        _currentDirection = direction.normalized;
    }

    private void Update()
    {
        if (_currentDirection != Vector3.zero)
        {
            transform.Translate(_currentDirection * _speed * Time.deltaTime, Space.World);
        }
    }
}