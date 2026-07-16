using UnityEngine;

public class MagicBuffItem : MonoBehaviour
{
    public int extraMagicDamage = 10;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && c.name == "Fairy")
        {
            c.GetComponent<FairyAttack>()?.BoostDamage(extraMagicDamage);
            
            Destroy(gameObject);
        }
    }
}