using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject groundPrefab;    // Ground 프리팹 (예: Ground.prefab)
    public Transform player;           // 플레이어(종이비행기) Transform
    public float groundWidth = 20f;    // Ground 하나의 가로 길이 (x축 기준)
    public int groundBuffer = 3;       // 플레이어 앞쪽으로 몇 개를 미리 만들어 둘지

    private float lastSpawnX = 0f;

    void Start()
    {
        // 초기 블록들 생성
        for (int i = 0; i < groundBuffer; i++)
        {
            SpawnGround(i * groundWidth);
        }

        lastSpawnX = (groundBuffer - 1) * groundWidth;
    }

    void Update()
    {
        // 플레이어가 마지막 생성 위치에서 일정 거리 이내로 접근하면 새 블록 생성
        if (player.position.x + groundBuffer * groundWidth > lastSpawnX)
        {
            lastSpawnX += groundWidth;
            SpawnGround(lastSpawnX);
        }
    }

    void SpawnGround(float xPosition)
    {
        Instantiate(groundPrefab, new Vector3(xPosition, 0, 0), Quaternion.identity);
    }
}
