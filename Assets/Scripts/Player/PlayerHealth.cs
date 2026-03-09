using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage, health now {currentHealth}");

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        if (playerController != null)
            playerController.Die();
    }
}
