using Spawners;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private SpawnPointGenerator _pointGenerator;

    protected override void Spawn(Enemy enemy)
    {
        Vector3 spawnPoint = _pointGenerator.GetRandomPoint().position;

        Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        base.Spawn(enemy);
        enemy.Init(spawnPoint, moveDirection);
        enemy.Falled += OnEnemyFall;
    }

    private void OnEnemyFall(Enemy enemy)
    {
        enemy.Falled -= OnEnemyFall;
        ReleaseToPool(enemy);
    }
}

