using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyQuantity;
    Camera mainCamera;
    [SerializeField] float spawnRate = 1;
    private Rect spawnArea;

    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemyOutsideCamera", 3, spawnRate);
    }
    private void Update()
    {
        CalculateSpawnArea();
    }
    private void LateUpdate() {
        
        enemyQuantity = this.transform.childCount;
    }
    private void CalculateSpawnArea()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float spawnAreaWidth = cameraWidth * 1.5f;// Adjust the factor as needed
        float spawnAreaHeight = cameraHeight * 1.5f; // Adjust the factor as needed

        spawnArea = new Rect();
        spawnArea.width = spawnAreaWidth;
        spawnArea.height = spawnAreaHeight;
        spawnArea.center = mainCamera.transform.position;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * Mathf.Max(spawnArea.width, spawnArea.height) / 2f;
        Vector3 spawnPosition = spawnArea.center + new Vector2(randomPoint.x, randomPoint.y);

        return spawnPosition;
    }

    private bool IsPositionInsideCamera(Vector3 position)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);
        return viewportPoint.x >= 0f && viewportPoint.x <= 1f && viewportPoint.y >= 0f && viewportPoint.y <= 1f;
    }

    private void SpawnEnemyOutsideCamera()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        while (IsPositionInsideCamera(spawnPosition))
        {
            spawnPosition = GetRandomSpawnPosition();
        }

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);
    }


}
