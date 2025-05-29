using UnityEngine;

public class PaperPlaneController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float windForce = 5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.clickClip,0.8f);
            Vector3 clickWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickWorldPos.z = 0;

            float distance = Vector2.Distance(rb.transform.position, clickWorldPos);
            float scaledForce = Mathf.Clamp(windForce / distance, 0, windForce);

            Vector2 direction = (rb.transform.position - clickWorldPos).normalized;

            rb.AddForce(direction * windForce, ForceMode2D.Impulse);

            // (선택) 디버깅용 로그
            Debug.Log($"Click at {clickWorldPos}, direction {direction}, force {direction * windForce}");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            GameManager.Instance.GameOver();
        }

        if (collision.collider.CompareTag("Leaf"))
        {
            Debug.Log("플레이어가 낙엽에 충돌!");
            SoundManager.Instance.PlaySFX(SoundManager.Instance.leafHitClip, 0.6f);
        }
    }


}
