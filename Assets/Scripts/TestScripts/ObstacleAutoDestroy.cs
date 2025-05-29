using UnityEngine;

public class ObstacleAutoDestroy : MonoBehaviour
{
    public Transform player;
    public float maxBehindDistance = 1000f;
    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("Player 태그가 붙은 오브젝트를 찾지 못했습니다!");
            }
        }
    }


    void Update()
    {
        if (player == null) return;

        float distanceX = player.position.x - transform.position.x;

        if (distanceX > maxBehindDistance)
        {
            Destroy(gameObject);
        }
    }
}
