using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TextMeshProUGUI healthText;
    private int currentHealth;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (healthText != null)
            healthText.text = $"Health: {currentHealth}";
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
