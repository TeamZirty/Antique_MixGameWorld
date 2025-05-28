using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public Transform player;
    public float backgroundWidth;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = player.position.x * (1 - 1f); // 기본 반복용, 고정
        float dist = player.position.x;

        transform.position = new Vector3(startPos.x + dist, transform.position.y, transform.position.z);

        if (dist > startPos.x + backgroundWidth)
        {
            startPos.x += backgroundWidth;
        }
        else if (dist < startPos.x - backgroundWidth)
        {
            startPos.x -= backgroundWidth;
        }
    }
}
