using UnityEngine;
public class CombatSystem : MonoBehaviour {
    public float attackRange = 3f;
    public float attackCooldown = 0.5f;
    public int attackDamage = 1;
    private float lastAttackTime;
    void Update() {
        if (Time.time >= lastAttackTime + attackCooldown) AttackNearestEnemy();
    }
    void AttackNearestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestDistance = attackRange;
        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null) {
            Enemy enemyScript = nearestEnemy.GetComponent<Enemy>();
            if (enemyScript != null) {
                enemyScript.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }
}