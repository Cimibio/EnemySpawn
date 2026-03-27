using UnityEngine;

public class SpawnPointGenerator : MonoBehaviour
{
    [Header("Настройки генерации")]
    [SerializeField] SpawnPoint _spawnPointPrefab;
    [SerializeField][Tooltip("Минимальное количество точек спавна")] private int _minPoints = 3;
    [SerializeField][Tooltip("Максимальное количество точек спавна")] private int _maxPoints = 8;
    [SerializeField] private float _xOffset = 10;
    [SerializeField] private float _zOffset = 10;
    [SerializeField] private float _yOffset = 1f;

    [Header("Визуализация")]
    [SerializeField] private Color _gizmoColor = Color.green;
    [SerializeField] private float _gizmoRadius = 0.5f;

    private void Awake()
    {
        Generate();
    }

    public Transform GetRandomPoint()
    {
        int count = transform.childCount;

        if (count == 0)
            return transform;

        return transform.GetChild(Random.Range(0, count));
    }

    private void Generate()
    {
        int count = Random.Range(_minPoints, _maxPoints);

        for (int i = 0; i < count; i++)
        {
            SpawnPoint point = Instantiate(_spawnPointPrefab, transform);
            point.transform.position = CalculateRandomPosition();
        }
    }

    private Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(transform.position.x - _xOffset, transform.position.x + _xOffset);
        float z = Random.Range(transform.position.z - _zOffset, transform.position.z + _zOffset);
        float y = transform.position.y + _yOffset;

        return new Vector3(x, y, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;

        foreach (Transform child in transform)
        {
            Gizmos.DrawSphere(child.position, _gizmoRadius);
            Gizmos.DrawLine(transform.position, child.position);
        }
    }
}
