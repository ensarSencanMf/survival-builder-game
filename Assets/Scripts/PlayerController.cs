using UnityEngine;

// PlayerController sınıfı - karakter hareketini kontrol eder
public class PlayerController : MonoBehaviour {
    float moveSpeed = 5f;
    private void Update() {
        Move();
    }
    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}