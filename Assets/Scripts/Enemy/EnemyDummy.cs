using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    [SerializeField] private int damageToPlayer = 2;
    [SerializeField] private GameObject damagePopupPrefab;
    
    private int currentHealth;

    public void TakeDamage(int damage)
    {
        if (damagePopupPrefab != null)
        {
            Vector3 spawnPos = transform.position + Vector3.up * 1.5f;
            GameObject popup = Instantiate(damagePopupPrefab, spawnPos, Quaternion.identity);
            popup.GetComponent<DamagePopup>().SetDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
                playerHealth.TakeDamage(damageToPlayer);
        }
    }
}
