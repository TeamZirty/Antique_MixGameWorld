using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(target.position.x, target.position.y, -10) + offset;
    }
}
