using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public SpikeTrap[] targetSpikes; 
    
    [Header("تنظیمات پله شوالیه")]
    public bool isKnightPlate = true;
    public float slowOffInterval = 1.5f;     // زمان کند (وقتی شوالیه روی پله است)
    public float normalOffInterval = 0.2f;   // زمان سریع (وقتی شوالیه از پله می‌رود)
    
    [Header("تنظیمات پله پری")]
    public bool isFairyPlate = false;   

    private Vector3 originalScale;
    private bool isPressed = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPressed) return;

        // استفاده از نام رشته‌ای دقیق آبجکت به جای تگ
        if (isKnightPlate && other.gameObject.name == "Knight")
        {
            isPressed = true;
            UpdateSpikesOffInterval(slowOffInterval);
            GetComponent<SpriteRenderer>().color = Color.green;
            transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);
        }
        else if (isFairyPlate && other.gameObject.name == "Fairy")
        {
            isPressed = true;
            PermanentlyDisableSpikes();
            GetComponent<SpriteRenderer>().color = Color.blue; 
            transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // تشخیص خروج شوالیه با استفاده از نام آبجکت
        if (isKnightPlate && other.gameObject.name == "Knight" && isPressed)
        {
            isPressed = false;
            UpdateSpikesOffInterval(normalOffInterval);
            GetComponent<SpriteRenderer>().color = Color.white;
            transform.localScale = originalScale;
        }
    }

    void UpdateSpikesOffInterval(float val)
    {
        foreach (var s in targetSpikes) 
        {
            if (s != null) s.SetOffInterval(val);
        }
    }

    void PermanentlyDisableSpikes()
    {
        foreach (var s in targetSpikes) 
        {
            if (s != null) s.DeactivatePermanently();
        }
    }
}