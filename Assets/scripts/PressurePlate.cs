using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public SpikeTrap[] targetSpikes; // تغییر به آرایه برای گرفتن چندین تیغ
    public float slowInterval = 2.0f;
    
    private float originalInterval;
    private Vector3 originalScale;
    private bool isPressed = false;

    void Start()
    {
        if (targetSpikes.Length > 0 && targetSpikes[0] != null)
            originalInterval = targetSpikes[0].toggleInterval;
            
        originalScale = transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // چک کردن کاراکتر نایت و موقعیت ایستادن
        if (collision.gameObject.name == "Knight" && !isPressed && collision.transform.position.y > transform.position.y)
        {
            isPressed = true;
            updSpikes(slowInterval);
            GetComponent<SpriteRenderer>().color = Color.green;
            transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Knight" && isPressed)
        {
            isPressed = false;
            updSpikes(originalInterval);
            GetComponent<SpriteRenderer>().color = Color.white;
            transform.localScale = originalScale;
        }
    }

    // تابع مینیمال برای آپدیت هم‌زمان تمام تیغ‌های متصل شده
    void updSpikes(float val)
    {
        foreach (var s in targetSpikes) 
        {
            if (s != null) s.SlowDownSpikes(val);
        }
    }
}