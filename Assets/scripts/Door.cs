using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject closedStateObject; 
    public GameObject openStateObject; 
    public string sceneName; 
    public bool isFinalDoor; // برای در چهارم این تیک را در Inspector بزن

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
            // اگر در چهارم است و هنوز ۳ ستاره جمع نشده، اجازه ورود نده
            if (isFinalDoor && !GameManager.Instance.AllStarsCollected()) 
            {
                Debug.Log("Locked!");
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