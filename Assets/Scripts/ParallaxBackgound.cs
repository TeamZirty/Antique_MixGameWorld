using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player;             // 플레이어 참조
    public Transform[] backgrounds;      // 배경 레이어 배열 (산, 하늘 순)
    public float[] parallaxScales;       // 각 레이어의 속도 비율
    public float smoothing = 1f;         // 부드럽게 따라가기

    private Vector3 previousPlayerPos;

    void Start()
    {
        previousPlayerPos = player.position;
    }

    void Update()
    {
        Vector3 delta = player.position - previousPlayerPos;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = delta.x * parallaxScales[i];
            float targetX = backgrounds[i].position.x + parallaxX;

            Vector3 backgroundTargetPos = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);

            // 부드럽게 이동
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
            Debug.Log("패럴렉스 작동중");
        }

        previousPlayerPos = player.position;
    }
}
