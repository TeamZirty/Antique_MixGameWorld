using UnityEngine;

public class FanSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] fanPrefabs;
    public float spawnAheadDistance = 100f;    // 플레이어 앞쪽 기본 거리
    public float minSpawnDistance = 20f;
    public float maxSpawnDistance = 40f;
    public float minY = -2f;
    public float maxY = 2f;
    public int minFanCount = 1;
    public int maxFanCount = 2;
    public float fanSpacing = 2f;

    public int distanceStep = 1000;
    public int extraFanPerStep = 1;

    private float nextSpawnX;

    void Start()
    {
        SetNextSpawnX();
    }

    void Update()
    {
        if (player.position.x >= nextSpawnX - spawnAheadDistance)
        {
            SpawnFans();
            SetNextSpawnX();
        }
    }

    void SetNextSpawnX()
    {
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        nextSpawnX = player.position.x + spawnAheadDistance + randomDistance;
    }

    void SpawnFans()
    {
        int baseCount = Random.Range(minFanCount, maxFanCount + 1);

        int stepsPassed = Mathf.FloorToInt(player.position.x / distanceStep);
        int extraCount = stepsPassed * extraFanPerStep;

        int totalFanCount = baseCount + extraCount;

        Debug.Log($"Spawning {totalFanCount} fans at distance {nextSpawnX}");

        for (int i = 0; i < totalFanCount; i++)
        {
            int prefabIndex = Random.Range(0, fanPrefabs.Length);
            GameObject prefab = fanPrefabs[prefabIndex];

            float randomY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(
                nextSpawnX + i * fanSpacing,
                randomY,
                0f
            );

            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
