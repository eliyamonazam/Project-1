using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.GetComponent<Health>()?.Heal(healAmount);
            Destroy(gameObject); 
        }
    }
}