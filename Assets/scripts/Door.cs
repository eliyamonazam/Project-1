using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedStateObject; 
    public GameObject openStateObject; 

    public string sceneName; 

    void Start()
    {
        closedStateObject.SetActive(true);
        openStateObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player")) 
        {
            closedStateObject.SetActive(false);
            openStateObject.SetActive(true);
            
            // کد دوستت:
            // SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player")) 
        {
        
            closedStateObject.SetActive(true);
            openStateObject.SetActive(false);
        }
    }
}