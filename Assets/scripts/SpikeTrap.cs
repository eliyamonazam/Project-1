using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    public float toggleInterval = 0.2f; 
    private BoxCollider2D spikeCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spikeCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleSpikes());
    }

    IEnumerator ToggleSpikes()
    {
        while (true)
        {
            spikeCollider.enabled = true;
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(toggleInterval);

            spikeCollider.enabled = false;
            spriteRenderer.color = Color.gray;
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    public void SlowDownSpikes(float newInterval)
    {
        toggleInterval = newInterval;
    }
}