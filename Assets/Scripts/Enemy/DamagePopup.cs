using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float disappearTime = 0.5f;
    [SerializeField] private float moveSpeed = 1f;

    private TextMeshPro textMesh;
    private float timer;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        
        if (textMesh == null)
            textMesh = GetComponentInChildren<TextMeshPro>();
    }

    public void SetDamage(int damage)
    {
        textMesh.text = damage.ToString();
        timer = disappearTime;
    }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);
    }
}
