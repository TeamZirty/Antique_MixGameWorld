using UnityEngine;

public class SimpleLoopingBackground : MonoBehaviour
{
    public Transform player;
    public Transform[] backgrounds;   // 2개만 넣음
    public float backgroundWidth;     // Sprite 한 장 폭
    public float parallaxFactor = 0.5f;

    private int leftIndex = 0;
    private int rightIndex;

    void Start()
    {
        rightIndex = backgrounds.Length - 1;

        // 초기 정렬
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = new Vector3(i * backgroundWidth, backgrounds[i].position.y, backgrounds[i].position.z);
        }
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x * parallaxFactor, transform.position.y, transform.position.z);

        if (player.position.x > backgrounds[rightIndex].position.x - backgroundWidth)
        {
            ScrollRight();
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
}
