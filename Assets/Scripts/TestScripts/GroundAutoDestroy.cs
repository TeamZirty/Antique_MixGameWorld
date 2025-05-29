using UnityEngine;

public class GroundAutoDestroy : MonoBehaviour
{
    public Transform player;
    public float maxBehindDistance = 2000f;  // 땅은 2000 거리 뒤로 밀리면 제거

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
                Debug.LogWarning("Couldn't Find Player Object");
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
