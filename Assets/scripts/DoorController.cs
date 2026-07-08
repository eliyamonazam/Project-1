using UnityEngine;

public class DoorController : MonoBehaviour
{
    public SpriteRenderer doorRenderer;
    public Sprite closedSprite;
    public Sprite openSprite;
    public BoxCollider2D solidCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fairy"))
        {
            doorRenderer.sprite = openSprite;
            solidCollider.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fairy"))
        {
            doorRenderer.sprite = closedSprite;
            solidCollider.enabled = true;
        }
    }
}