using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyDummy : MonoBehaviour
{
    [SerializeField] private int damageToPlayer = 2;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float displayDuration = 1f;

    private int accumulatedDamage = 0;
    private Coroutine resetCoroutine;

    private void Start()
    {
        if (damageText != null)
            damageText.text = "0";
    }

    public void TakeDamage(int damage)
    {
        accumulatedDamage += damage;
        
        if (damageText != null)
            damageText.text = accumulatedDamage.ToString();

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        resetCoroutine = StartCoroutine(ResetDamageAfterDelay());
    }

    private IEnumerator ResetDamageAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        accumulatedDamage = 0;

        if (damageText != null)
            damageText.text = "0";

        resetCoroutine = null;
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
