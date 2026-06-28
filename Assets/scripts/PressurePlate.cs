using UnityEngine;
public class PressurePlate : MonoBehaviour
{
    public SpikeTrap targetSpikes;
    public float slowInterval = 2.0f;
    private float originalInterval;
    private Vector3 originalScale;
    private float pressedScaleY = 0.1f;

    void Start() {
        if (targetSpikes != null) {
            originalInterval = targetSpikes.toggleInterval;
        }
        originalScale = transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Knight" && targetSpikes != null) {
            targetSpikes.SlowDownSpikes(slowInterval);
            GetComponent<SpriteRenderer>().color = Color.green;
            transform.localScale = new Vector3(originalScale.x, pressedScaleY, originalScale.z);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Knight" && targetSpikes != null) {
            targetSpikes.SlowDownSpikes(originalInterval);
            GetComponent<SpriteRenderer>().color = Color.white;
            transform.localScale = originalScale;
        }
    }
}