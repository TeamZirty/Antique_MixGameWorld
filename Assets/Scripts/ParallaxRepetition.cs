using UnityEngine;

public class ParallaxRepetition : MonoBehaviour
{
    public Transform player;              // 플레이어
    public float parallaxScale = 0.5f;    // 패럴럭스 이동 속도
    public float backgroundWidth = 20f;   // 배경 이미지 한 장의 너비

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 기본 패럴럭스 이동
        float dist = player.position.x * parallaxScale;
        transform.position = new Vector3(startPos.x + dist, transform.position.y, transform.position.z);

        // 플레이어가 한 구간을 지나면 배경 위치 반복
        float temp = player.position.x * (1 - parallaxScale);
        if (temp > startPos.x + backgroundWidth)
        {
            startPos.x += backgroundWidth;
        }
        else if (temp < startPos.x - backgroundWidth)
        {
            startPos.x -= backgroundWidth;
        }
    }
}
