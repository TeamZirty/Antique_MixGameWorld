using UnityEngine;

public class ThreeBlockInfiniteBackground : MonoBehaviour
{
    public Transform player;
    public Transform[] backgrounds;   // 3개 넣음
    public float backgroundWidth = 64f;  // 256px / 4

    private int leftIndex = 0;
    private int rightIndex = 2;

    void Start()
    {
        // 초기 정렬
        backgrounds[0].position = new Vector3(0, 0, 0);
        backgrounds[1].position = new Vector3(backgroundWidth, 0, 0);
        backgrounds[2].position = new Vector3(2 * backgroundWidth, 0, 0);
    }

    void Update()
    {
        // 플레이어가 오른쪽 끝으로 다가가면 → 왼쪽 블록을 오른쪽으로 보내기
        if (player.position.x > backgrounds[rightIndex].position.x - backgroundWidth)
        {
            ScrollRight();
        }

        // (선택) 왼쪽 무한 반복도 할 경우
        if (player.position.x < backgrounds[leftIndex].position.x + backgroundWidth)
        {
            ScrollLeft();
        }
    }

    void ScrollRight()
    {
        backgrounds[leftIndex].position = new Vector3(
            backgrounds[rightIndex].position.x + backgroundWidth,
            backgrounds[leftIndex].position.y,
            backgrounds[leftIndex].position.z
        );

        rightIndex = leftIndex;
        leftIndex = (leftIndex + 1) % backgrounds.Length;
    }

    void ScrollLeft()
    {
        backgrounds[rightIndex].position = new Vector3(
            backgrounds[leftIndex].position.x - backgroundWidth,
            backgrounds[rightIndex].position.y,
            backgrounds[rightIndex].position.z
        );

        leftIndex = rightIndex;
        rightIndex = (rightIndex - 1 + backgrounds.Length) % backgrounds.Length;
    }
}
