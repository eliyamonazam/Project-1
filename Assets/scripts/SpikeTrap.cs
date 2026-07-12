using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    public float onInterval = 0.2f;     
    public float offInterval = 0.2f;    
    public int damageAmount = 20; 
    public float damageCooldown = 1f; 
    
    private SpriteRenderer spriteRenderer;
    private Coroutine toggleCoroutine;
    private bool isPermanentlyDisabled = false;
    private bool isDangerous = false; 
    private float lastDamageTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        toggleCoroutine = StartCoroutine(ToggleSpikes());
    }

    // تغییرات اصلی در این تابع انجام شده است (استفاده از تایمر داینامیک)
    IEnumerator ToggleSpikes()
    {
        while (!isPermanentlyDisabled)
        {
            // حالت روشن (قرمز و خطرناک)
            isDangerous = true;
            spriteRenderer.color = Color.red;
            
            float onTimer = 0;
            while (onTimer < onInterval && !isPermanentlyDisabled)
            {
                onTimer += Time.deltaTime;
                yield return null; // یک فریم صبر می‌کند
            }

            if (isPermanentlyDisabled) break;

            // حالت خاموش (خاکستری و امن)
            isDangerous = false;
            spriteRenderer.color = Color.gray;
            
            float offTimer = 0;
            // اینجا اگر شوالیه از پله پایین بیاید، offInterval بلافاصله کم می‌شود
            // و شرط این حلقه (offTimer < offInterval) سریعاً شکسته می‌شود!
            while (offTimer < offInterval && !isPermanentlyDisabled)
            {
                offTimer += Time.deltaTime;
                yield return null;
            }
        }
    }

    public void SetOffInterval(float newOffInterval)
    {
        if (!isPermanentlyDisabled)
        {
            offInterval = newOffInterval;
        }
    }

    public void DeactivatePermanently()
    {
        isPermanentlyDisabled = true;
        isDangerous = false; 
        if (toggleCoroutine != null) 
            StopCoroutine(toggleCoroutine);
        
        if (spriteRenderer != null) spriteRenderer.color = Color.gray; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ApplyDamageIfDangerous(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ApplyDamageIfDangerous(other);
    }

    void ApplyDamageIfDangerous(Collider2D other)
    {
        if (isPermanentlyDisabled || !isDangerous) return;

        if (Time.time - lastDamageTime >= damageCooldown)
        {
            Health targetHealth = other.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time; 
            }
        }
    }
}