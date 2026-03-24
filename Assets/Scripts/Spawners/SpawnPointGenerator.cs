using UnityEngine;

public class SpawnPointGenerator : MonoBehaviour
{
    [Header("Настройки генерации")]
    [SerializeField] private GameObject _startPoint;
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
        int count = _startPoint.transform.childCount;

        if (count == 0)
            return _startPoint.transform;

        return _startPoint.transform.GetChild(Random.Range(0, count));
    }

    private void Generate()
    {
        if (_startPoint == null)
            _startPoint = this.gameObject;

        int count = Random.Range(_minPoints, _maxPoints);

        for (int i = 0; i < count; i++)
        {
            GameObject point = new GameObject($"SpawnPoint_{i}");
            point.transform.SetParent(_startPoint.transform);
            point.transform.position = CalculateRandomPosition();
        }
    }

    private Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(_startPoint.transform.position.x - _xOffset, _startPoint.transform.position.x + _xOffset);
        float z = Random.Range(_startPoint.transform.position.z - _zOffset, _startPoint.transform.position.z + _zOffset);
        float y = _startPoint.transform.position.y + _yOffset;

        return new Vector3(x, y, z);
    }

    private void OnDrawGizmos()
    {
        if (_startPoint == null) return;

        Gizmos.color = _gizmoColor;
        foreach (Transform child in _startPoint.transform)
        {
            Gizmos.DrawSphere(child.position, _gizmoRadius);
            Gizmos.DrawLine(_startPoint.transform.position, child.position);
        }
    }
}
