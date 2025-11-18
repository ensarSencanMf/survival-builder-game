using UnityEngine;
public class CameraFollow : MonoBehaviour {
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -8f);
    public float smoothSpeed = 0.125f;
    void Start() {
        if (target == null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
    }
    void LateUpdate() {
        if (target != null) {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}