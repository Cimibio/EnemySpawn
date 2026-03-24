using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _minSpawnPoint = 3;
    [SerializeField] private int _maxSpawnPoint = 8;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private int _ySpawnOffset = 1;

    private GameObject[] _spawnPoints;

    private void Awake()
    {
        int number = Random.Range(_minSpawnPoint, _maxSpawnPoint);
        _spawnPoints = new GameObject[number];

        for (int i = 0; i < number; i++)
        {
            Vector3 position = GetRandomSpawnPoint();
            GameObject newPoint = new GameObject($"SpawnPoint#{i}");
            newPoint.transform.position = position;
            _spawnPoints[i] = newPoint;
        }
    }


    private Vector3 GetRandomSpawnPoint()
    {
        if (_startPoint == null) return transform.position;

        // Пытаемся получить коллайдер
        if (!_startPoint.TryGetComponent<Collider>(out Collider collider))
        {
            // Если его нет — добавляем (например, BoxCollider)
            collider = _startPoint.AddComponent<BoxCollider>();
            Debug.LogWarning($"На {_startPoint.name} не было коллайдера, добавлен BoxCollider.");
        }

        Bounds bounds = collider.bounds;

        float y = bounds.max.y + _ySpawnOffset;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }
}
