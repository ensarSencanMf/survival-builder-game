using UnityEngine;
using UnityEngine.UI;
public class BuildingPlatform : MonoBehaviour {
    public int requiredGold = 50;
    public GameObject platformObject;
    public Text progressText;
    private bool isBuilt = false;
    private GameManager gameManager;
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        if (platformObject != null) platformObject.SetActive(false);
        UpdateProgress();
    }
    void Update() {
        if (!isBuilt && gameManager != null) {
            UpdateProgress();
            if (gameManager.currentGold >= requiredGold) Build();
        }
    }
    void UpdateProgress() {
        if (progressText != null && gameManager != null) {
            progressText.text = gameManager.currentGold + " / " + requiredGold + " Altın";
        }
    }
    void Build() {
        isBuilt = true;
        gameManager.SpendGold(requiredGold);
        if (platformObject != null) platformObject.SetActive(true);
        if (progressText != null) progressText.text = "Tamamlandı!";
    }
}