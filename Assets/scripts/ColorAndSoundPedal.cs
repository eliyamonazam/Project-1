using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ColorAndSoundPedal : MonoBehaviour
{
    public Color pressedColor = Color.gray;
    public AudioClip pressSound;
    
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Color originalColor;
    private bool isPressed = false;
    
    private bool hasSoundPlayed = false; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Knight" && !isPressed)
        {
            isPressed = true;
            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = pressedColor;
            }
                        if (audioSource != null && pressSound != null && !hasSoundPlayed)
            {
                audioSource.PlayOneShot(pressSound);
                
                hasSoundPlayed = true; 
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Knight" && isPressed)
        {
            isPressed = false;
            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}