using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private bool canDamage = false;

    public void EnableHitbox()
    {
        canDamage = true;
        Debug.Log("Hitbox ENABLED");
    }

    public void DisableHitbox()
    {
        canDamage = false;
        Debug.Log("Hitbox DISABLED");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Hitbox triggered by {other.name}, tag: {other.tag}, canDamage: {canDamage}");

        if (!canDamage) return;

        if (other.CompareTag("Enemy"))
        {
            EnemyDummy enemy = other.GetComponent<EnemyDummy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                canDamage = false;
            }
        }
    }
}
