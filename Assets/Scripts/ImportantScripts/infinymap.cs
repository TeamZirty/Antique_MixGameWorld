//겹치지 않고 랜덤 맵 불러오기
/*using UnityEngine;
using System.Collections.Generic;

public class infinymap : MonoBehaviour
{
    [System.Serializable]
    public class BackgroundGroup
    {
        public string groupName;
        public GameObject[] prefabs;
        public float width;
        public int poolSizePerPrefab = 2;
    }

    public Transform player;
    public BackgroundGroup[] groups;
    public int initialBlocks = 3;
    public float parallaxFactor = 0.5f;

    private List<GameObject>[][] groupedPools;
    private GameObject[] activeBlocks;
    private int leftIndex = 0;
    private int rightIndex;

    void Start()
    {
        // 풀 생성
        groupedPools = new List<GameObject>[groups.Length][];
        for (int g = 0; g < groups.Length; g++)
        {
            groupedPools[g] = new List<GameObject>[groups[g].prefabs.Length];
            for (int p = 0; p < groups[g].prefabs.Length; p++)
            {
                groupedPools[g][p] = new List<GameObject>();
                for (int i = 0; i < groups[g].poolSizePerPrefab; i++)
                {
                    GameObject obj = Instantiate(groups[g].prefabs[p], transform);
                    obj.SetActive(false);
                    groupedPools[g][p].Add(obj);
                }
            }
        }

        // 초기 배치
        activeBlocks = new GameObject[initialBlocks];
        float spawnX = 0f;
        for (int i = 0; i < initialBlocks; i++)
        {
            int g = Random.Range(0, groups.Length);
            GameObject block = GetFromGroupPool(g);
            block.transform.position = new Vector3(spawnX, 0, 0);
            block.SetActive(true);
            activeBlocks[i] = block;
            spawnX += groups[g].width;
        }

        leftIndex = 0;
        rightIndex = activeBlocks.Length - 1;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x * parallaxFactor, transform.position.y, transform.position.z);

        var rightBlock = activeBlocks[rightIndex];
        float rightWidth = GetBlockWidth(rightBlock);
        if (player.position.x > rightBlock.transform.position.x - rightWidth)
        {
            ScrollRight();
        }
    }

    void ScrollRight()
    {
        int oldGroup = GetGroupIndex(activeBlocks[leftIndex]);
        ReturnToGroupPool(activeBlocks[leftIndex], oldGroup);

        int newGroup = Random.Range(0, groups.Length);
        GameObject newBlock = GetFromGroupPool(newGroup);
        newBlock.transform.position = new Vector3(
            activeBlocks[rightIndex].transform.position.x + groups[newGroup].width,
            0,
            0
        );
        newBlock.SetActive(true);

        activeBlocks[leftIndex] = newBlock;

        rightIndex = leftIndex;
        leftIndex = (leftIndex + 1) % activeBlocks.Length;
    }

    GameObject GetFromGroupPool(int groupIndex)
    {
        int prefabIndex = Random.Range(0, groups[groupIndex].prefabs.Length);
        var pool = groupedPools[groupIndex][prefabIndex];
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        // 풀 부족 시 추가 생성
        GameObject newObj = Instantiate(groups[groupIndex].prefabs[prefabIndex], transform);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

    void ReturnToGroupPool(GameObject obj, int groupIndex)
    {
        obj.SetActive(false);
    }

    int GetGroupIndex(GameObject obj)
    {
        for (int g = 0; g < groups.Length; g++)
        {
            foreach (var prefab in groups[g].prefabs)
            {
                if (obj.name.Contains(prefab.name))
                    return g;
            }
        }
        return 0;
    }

    float GetBlockWidth(GameObject block)
    {
        SpriteRenderer sr = block.GetComponentInChildren<SpriteRenderer>();
        return sr != null ? sr.bounds.size.x : 1f;
    }
}
*/