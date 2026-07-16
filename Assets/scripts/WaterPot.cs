using UnityEngine;

public class WaterPot : MonoBehaviour
{
    public GameObject uiHint;
    private bool isCarried = false, isNear = false;
    private Transform fairy;
    
    private static bool hasLearned = false; 

    void Start() => uiHint?.SetActive(false);

    void Update()
    {
        if (isNear && !isCarried && Input.GetKeyDown(KeyCode.E))
        {
            isCarried = true;
            transform.parent = fairy;
            transform.localPosition = new Vector3(0, 1f, 0);
            uiHint?.SetActive(false);
            
            hasLearned = true; 
        }
        else if (isCarried && Input.GetKeyDown(KeyCode.Q))
        {
            isCarried = false;
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && c.gameObject.name == "Fairy") 
        { 
            isNear = true; 
            fairy = c.transform; 
            
            if (!isCarried && !hasLearned) uiHint?.SetActive(true); 
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player")) 
        { 
            isNear = false; 
            fairy = null; 
            uiHint?.SetActive(false); 
        }
    }
}