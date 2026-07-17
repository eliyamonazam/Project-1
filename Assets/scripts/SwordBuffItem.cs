using UnityEngine;

public class SwordBuffItem : MonoBehaviour
{
    public int extraDamage = 10;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && c.name == "Knight")
        {
            c.GetComponent<PlayerCombat>()?.BoostDamage(extraDamage);
            Destroy(gameObject);
        }
    }
}