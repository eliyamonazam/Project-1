using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ۱. پیاده‌سازی الگوی Singleton
    public static GameManager Instance { get; private set; }

    // ۲. متغیرهای مربوط به ستاره‌ها با مقدار اولیه false
    public bool hasStar1 = false;
    public bool hasStar2 = false;
    public bool hasStar3 = false;

    private void Awake()
    {
        // بررسی وجود نمونه قبلی برای جلوگیری از تداخل
        if (Instance == null)
        {
            Instance = this;
            // جلوگیری از نابود شدن این آبجکت با تغییر صحنه
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // اگر یک GameManager از قبل وجود داشت، این یکی را نابود کن
            Destroy(gameObject);
        }
    }

    // ۳. متدی برای بررسی جمع‌آوری شدن تمام ستاره‌ها
    public bool AllStarsCollected()
    {
        // اگر هر سه متغیر true باشند، این متد true برمی‌گرداند
        return hasStar1 && hasStar2 && hasStar3;
    }
}