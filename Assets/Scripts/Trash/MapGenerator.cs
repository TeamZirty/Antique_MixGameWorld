using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform player;
    public float groundWidth = 20f;
    public int groundBuffer = 10;    // 풀 크기

    private Queue<GameObject> groundPool = new Queue<GameObject>();
    private float leftMostX = 0f;
    private float rightMostX = 0f;

    void Start()
    {
        // 초기 땅 풀 생성 및 배치
        for (int i = 0; i < groundBuffer; i++)
        {
            float x = i * groundWidth;
            GameObject ground = Instantiate(groundPrefab, new Vector3(x, 0, 0), Quaternion.identity);
            groundPool.Enqueue(ground);
        }

        leftMostX = 0f;
        rightMostX = (groundBuffer - 1) * groundWidth;
    }

    void Update()
    {
        // 앞으로 갈 때: 새 땅을 맨 앞에 붙임
        if (player.position.x + groundWidth > rightMostX)
        {
            ReuseGroundForward();
        }

        // 뒤로 갈 때: 새 땅을 맨 뒤에 붙임
        if (player.position.x - groundWidth < leftMostX)
        {
            ReuseGroundBackward();
        }
    }

    void ReuseGroundForward()
    {
        GameObject ground = groundPool.Dequeue(); // 맨 앞 블록 꺼내기

        rightMostX += groundWidth;
        ground.transform.position = new Vector3(rightMostX, 0, 0);

        groundPool.Enqueue(ground); // 다시 맨 뒤로 넣기

        leftMostX += groundWidth; // 왼쪽 경계도 한 칸 밀어줌
    }

    void ReuseGroundBackward()
    {
        GameObject ground = groundPool.Dequeue(); // 맨 앞 블록 꺼내기

        leftMostX -= groundWidth;
        ground.transform.position = new Vector3(leftMostX, 0, 0);

        groundPool.Enqueue(ground); // 다시 맨 뒤로 넣기

        rightMostX -= groundWidth; // 오른쪽 경계도 한 칸 당겨줌
    }
}
