using UnityEngine;
public class Enemy : MonoBehaviour {
    public int health = 3;
    public float moveSpeed = 2f;
    public GameObject coinPrefab;
    private Transform player;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < 10f) {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(player);
            }
        }
    }
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) Die();
    }
    void Die() {
        int coinCount = Random.Range(5, 11);
        for (int i = 0; i < coinCount; i++) {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * 2f;
            spawnPos.y = 0.5f;
            if (coinPrefab != null) Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}