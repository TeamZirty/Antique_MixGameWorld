using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] obstaclePrefabs;
    public float spawnAheadDistance = 100f;    // 플레이어 앞으로 떨어져 소환될 기본 거리
    public float minY = -2f;
    public float maxY = 2f;
    public int minObstacleCount = 1;
    public int maxObstacleCount = 2;
    public float obstacleSpacing = 2f;
    public float minExtraDistance = 10f;
    public float maxExtraDistance = 20f;

    public int distanceStep = 1000;           // 1000m마다
    public int extraObstaclePerStep = 1;      // 생성 추가량

    private float nextSpawnX;

    void Start()
    {
        SetNextSpawnX();
    }

    void Update()
    {
        if (player.position.x >= nextSpawnX - spawnAheadDistance)
        {
            SpawnObstacles();
            SetNextSpawnX();
        }
    }

    void SetNextSpawnX()
    {
        float extraDistance = Random.Range(minExtraDistance, maxExtraDistance);
        nextSpawnX = player.position.x + spawnAheadDistance + extraDistance;
    }

    void SpawnObstacles()
    {
        int baseCount = Random.Range(minObstacleCount, maxObstacleCount + 1);

        int stepsPassed = Mathf.FloorToInt(player.position.x / distanceStep);
        int extraCount = stepsPassed * extraObstaclePerStep;

        int totalObstacleCount = baseCount + extraCount;

        Debug.Log($"Spawning {totalObstacleCount} obstacles at distance {nextSpawnX}");

        for (int i = 0; i < totalObstacleCount; i++)
        {
            int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject prefab = obstaclePrefabs[prefabIndex];

            float randomY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(
                nextSpawnX + i * obstacleSpacing,
                randomY,
                0f
            );

            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
