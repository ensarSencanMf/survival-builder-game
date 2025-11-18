using UnityEngine;
public class Coin : MonoBehaviour {
    public int goldValue = 1;
    public float rotationSpeed = 100f;
    public float collectRange = 2f;
    private Transform player;
    void Start() {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }
    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < collectRange) Collect();
        }
    }
    void Collect() {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null) gameManager.AddGold(goldValue);
        Destroy(gameObject);
    }
}