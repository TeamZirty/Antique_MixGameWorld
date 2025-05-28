using UnityEngine;

public class ParallaxInfiniteRandomBackground : MonoBehaviour
{
    [System.Serializable]
    public class BackgroundBlock
    {
        public Transform prefab;      // 땅, 구름, 산 등 Prefab
        public float width;           // 개별 폭
    }

    public Transform player;
    public BackgroundBlock[] blockTypes;      // 랜덤 선택용 블록 종류
    public int initialBlocks = 3;             // 처음 깔릴 개수
    public float parallaxFactor = 0.5f;

    private Transform[] activeBlocks;         // 현재 씬에 배치된 블록들
    private int leftIndex = 0;
    private int rightIndex;

    void Start()
    {
        activeBlocks = new Transform[initialBlocks];

        float spawnX = 0f;
        for (int i = 0; i < initialBlocks; i++)
        {
            int randomIndex = Random.Range(0, blockTypes.Length);
            var block = Instantiate(blockTypes[randomIndex].prefab, new Vector3(spawnX, 0, 0), Quaternion.identity, transform);
            activeBlocks[i] = block;
            spawnX += blockTypes[randomIndex].width;
        }

        leftIndex = 0;
        rightIndex = activeBlocks.Length - 1;
    }

    void Update()
    {
        float deltaX = player.position.x * parallaxFactor;
        transform.position = new Vector3(deltaX, transform.position.y, transform.position.z);

        var rightBlock = activeBlocks[rightIndex];
        var rightWidth = GetBlockWidth(rightBlock);
        if (player.position.x > rightBlock.position.x - rightWidth)
        {
            ScrollRight();
        }

        var leftBlock = activeBlocks[leftIndex];
        var leftWidth = GetBlockWidth(leftBlock);
        if (player.position.x < leftBlock.position.x + leftWidth)
        {
            ScrollLeft();
        }
    }

    void ScrollRight()
    {
        Destroy(activeBlocks[leftIndex].gameObject);

        int randomIndex = Random.Range(0, blockTypes.Length);
        var newBlock = Instantiate(
            blockTypes[randomIndex].prefab,
            new Vector3(activeBlocks[rightIndex].position.x + blockTypes[randomIndex].width, 0, 0),
            Quaternion.identity,
            transform
        );

        activeBlocks[leftIndex] = newBlock;

        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex >= activeBlocks.Length)
            leftIndex = 0;
    }

    void ScrollLeft()
    {
        Destroy(activeBlocks[rightIndex].gameObject);

        int randomIndex = Random.Range(0, blockTypes.Length);
        var newBlock = Instantiate(
            blockTypes[randomIndex].prefab,
            new Vector3(activeBlocks[leftIndex].position.x - blockTypes[randomIndex].width, 0, 0),
            Quaternion.identity,
            transform
        );

        activeBlocks[rightIndex] = newBlock;

        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = activeBlocks.Length - 1;
    }

    float GetBlockWidth(Transform block)
    {
        SpriteRenderer sr = block.GetComponentInChildren<SpriteRenderer>();
        return sr.bounds.size.x;
    }
}
