using UnityEngine;

public class FanObstacle : MonoBehaviour
{
    public float windForce = 5f;              // 바람 힘
    public float windRange = 5f;              // 바람 거리
    public Vector2 windDirection = Vector2.right; // 바람 방향 (기본: 오른쪽)

    private void OnDrawGizmosSelected()
    {
        // 에디터에서 바람 영역 시각화
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(windDirection.normalized * windRange));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlayFanSoundAtPosition(transform.position);

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(windDirection.normalized * windForce * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }
}
