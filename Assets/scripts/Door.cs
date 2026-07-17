using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject closedStateObject; 
    public GameObject openStateObject; 
    public string sceneName;

    [Header("تنظیمات نوع در")]
    [Tooltip("اگر این در بازیکن را به سین اصلی برمی‌گرداند، این تیک را بزنید")]
    public bool isReturnDoor; 

    [Tooltip("اگر این در نهایی درون مرحله است و فقط باید مسیر را در همین صحنه باز کند، این تیک را بزنید")]
    public bool isFinalDoor; 

    void Start()
    {
        closedStateObject.SetActive(true);
        openStateObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        string n = c.gameObject.name;
        
        if (n == "Knight" || n == "Fairy") 
        {
            if (isReturnDoor)
            {
                closedStateObject.SetActive(false);
                openStateObject.SetActive(true);

                GameManager.Instance.SaveCurrentMissionStars();
                
                GameManager.Instance.ResetStars();

                SceneManager.LoadScene(sceneName);
                return;
            }

            if (isFinalDoor) 
            {
                if (!GameManager.Instance.AllStarsCollected()) 
                {
                    Debug.Log("Locked! هنوز ۳ ستاره این بخش را جمع نکرده‌اید.");
                    return; 
                }

                closedStateObject.SetActive(false);
                openStateObject.SetActive(true);
                
                GameManager.Instance.ResetStars();
                return;
            }

            closedStateObject.SetActive(false);
            openStateObject.SetActive(true);
            
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        string n = c.gameObject.name;
        
        if (n == "Knight" || n == "Fairy") 
        {
            closedStateObject.SetActive(true);
            openStateObject.SetActive(false);
        }
    }
}