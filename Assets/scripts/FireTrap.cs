using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public int damage = 10;
    public Sprite extinguishedSprite;
    
    private bool isExtinguished = false;
    private AudioSource audioSource;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isExtinguished) return;

        if (other.CompareTag("Player"))
        {
            WaterPot carriedPot = other.GetComponentInChildren<WaterPot>();

            if (carriedPot != null)
            {
                ExtinguishFire();
                Destroy(carriedPot.gameObject); 
            }
            else
            {
                audioSource.Play();
                other.GetComponent<Health>()?.TakeDamage(damage);
            }
        }
    }

    void ExtinguishFire()
    {
        isExtinguished = true;
        animator.enabled = false;
        spriteRenderer.sprite = extinguishedSprite;
    }
}