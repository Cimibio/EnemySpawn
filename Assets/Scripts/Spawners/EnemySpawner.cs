using Spawners;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private SpawnPointGenerator _pointGenerator;

    protected override void ActionOnGet(Enemy enemy)
    {
        Vector3 spawnPoint = _pointGenerator.GetRandomPoint().position;
        float randomYAngle = Random.Range(0f, 360f);
        Quaternion direction = Quaternion.Euler(0, randomYAngle, 0);

        base.ActionOnGet(enemy);
        enemy.Init(spawnPoint, direction);

        enemy.Falled += OnEnemyFall;
    }

    private void OnEnemyFall(Enemy enemy)
    {
        enemy.Falled -= OnEnemyFall;
        ReleaseToPool(enemy);
    }
}

