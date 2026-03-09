using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private bool canDamage = false;

    public void EnableHitbox()
    {
        canDamage = true;
    }

    public void DisableHitbox()
    {
        canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
