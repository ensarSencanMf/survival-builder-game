using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public int currentGold = 0;
    public Text goldText;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public int startingEnemies = 5;
    void Start() {
        SpawnEnemies();
        UpdateGoldUI();
    }
    void SpawnEnemies() {
        for (int i = 0; i < startingEnemies; i++) {
            Vector3 spawnPos = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-15f, 15f));
            if (enemyPrefab != null) Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
    public void AddGold(int amount) {
        currentGold += amount;
        UpdateGoldUI();
    }
    public void SpendGold(int amount) {
        currentGold -= amount;
        UpdateGoldUI();
    }
    void UpdateGoldUI() {
        if (goldText != null) goldText.text = "Altın: " + currentGold;
    }
}