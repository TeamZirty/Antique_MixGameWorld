using UnityEngine;
using System.Collections.Generic;

public class BackgroundGroupRunner : MonoBehaviour
{
    public Transform player;
    public GameObject[] prefabs;
    public float width = 64f;
    public int poolSizePerPrefab = 3;
    public int initialBlocks = 3;
    public float parallaxFactor = 0.5f;
    public float yOffset = 0f;

    private List<GameObject>[] pools;
    private GameObject[] activeBlocks;
    private int leftIndex = 0;
    private int rightIndex;

    void Start()
    {
        // 풀 생성
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
            for (int j = 0; j < poolSizePerPrefab; j++)
            {
                GameObject obj = Instantiate(prefabs[i], transform);
                obj.SetActive(false);
                pools[i].Add(obj);
            }
        }

        // 초기 배치
        activeBlocks = new GameObject[initialBlocks];
        float spawnX = 0f;
        for (int i = 0; i < initialBlocks; i++)
        {
            GameObject block = GetFromPool();
            block.transform.position = new Vector3(spawnX, yOffset, 0);
            block.SetActive(true);
            activeBlocks[i] = block;
            spawnX += width;
        }

        leftIndex = 0;
        rightIndex = activeBlocks.Length - 1;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x * parallaxFactor, transform.position.y, transform.position.z);

        // 앞으로 이동
        var rightBlock = activeBlocks[rightIndex];
        if (player.position.x > rightBlock.transform.position.x - width)
        {
            ScrollRight();
        }

        // 뒤로 이동
        var leftBlock = activeBlocks[leftIndex];
        if (player.position.x < leftBlock.transform.position.x + width)
        {
            ScrollLeft();
        }
    }

    void ScrollRight()
    {
        ReturnToPool(activeBlocks[leftIndex]);

        GameObject newBlock = GetFromPool();
        newBlock.transform.position = new Vector3(
            activeBlocks[rightIndex].transform.position.x + width,
            yOffset,
            0
        );
        newBlock.SetActive(true);

        activeBlocks[leftIndex] = newBlock;

        rightIndex = leftIndex;
        leftIndex = (leftIndex + 1) % activeBlocks.Length;
    }

    void ScrollLeft()
    {
        ReturnToPool(activeBlocks[rightIndex]);

        GameObject newBlock = GetFromPool();
        newBlock.transform.position = new Vector3(
            activeBlocks[leftIndex].transform.position.x - width,
            yOffset,
            0
        );
        newBlock.SetActive(true);

        activeBlocks[rightIndex] = newBlock;

        leftIndex = rightIndex;
        rightIndex = (rightIndex - 1 + activeBlocks.Length) % activeBlocks.Length;
    }

    GameObject GetFromPool()
    {
        int prefabIndex = Random.Range(0, prefabs.Length);
        foreach (var obj in pools[prefabIndex])
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(prefabs[prefabIndex], transform);
        newObj.SetActive(false);
        pools[prefabIndex].Add(newObj);
        return newObj;
    }

    void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
