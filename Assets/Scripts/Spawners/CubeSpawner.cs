using Spawners;
using UnityEngine;

public class CubeSpawner : Spawner<Enemy>
{
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _minCubeLifetime = 2f;
    [SerializeField] private float _maxCubeLifetime = 5f;
    [SerializeField] private int _ySpawnOffset = 10;

    protected override void ActionOnGet(Enemy enemy)
    {
        enemy.transform.position = GetRandomSpawnPoint();

        base.ActionOnGet(enemy);
        float lifetime = Random.Range(_minCubeLifetime, _maxCubeLifetime);
        enemy.Init(lifetime);

        enemy.Expired += OnItemExpired;
    }

    private void OnItemExpired(Enemy cube)
    {
        cube.Expired -= OnItemExpired;
        ReleaseToPool(cube);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        if (_startPoint == null) return transform.position;

        Collider col = _startPoint.GetComponent<Collider>();
        Bounds bounds = col.bounds;

        float y = bounds.max.y + _ySpawnOffset;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }
}
