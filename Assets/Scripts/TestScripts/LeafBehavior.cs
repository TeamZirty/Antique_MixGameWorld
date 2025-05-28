using UnityEngine;

public class LeafBehavior : MonoBehaviour
{
    public float floatAmplitude = 0.5f;    // 위아래 흔들림 크기
    public float floatFrequency = 2f;      // 흔들림 속도
    public float rotationSpeed = 90f;      // 초당 회전 속도 (도)

    private float initialY;
    private float randomOffset;

    void Start()
    {
        initialY = transform.position.y;
        randomOffset = Random.Range(0f, Mathf.PI * 2); // 위아래 움직임 위상 랜덤
        rotationSpeed *= Random.Range(0.5f, 1.5f) * (Random.value < 0.5f ? 1 : -1); // 회전 속도·방향 랜덤
    }

    void Update()
    {
        // 위아래로 흔들리기 (사인파 기반)
        float newY = initialY + Mathf.Sin(Time.time * floatFrequency + randomOffset) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 계속 회전
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
