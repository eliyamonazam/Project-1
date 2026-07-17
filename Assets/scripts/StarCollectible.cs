using UnityEngine;
using UnityEngine.SceneManagement;

public class StarCollectible : MonoBehaviour
{
    public int starID; 
    
    [Header("تنظیمات پایان مرحله")]
    public bool finishesMission = false; 
    public string mainSceneName = "sara's wef"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knight") || other.CompareTag("Fairy"))
        {
            // ۱. ثبت در حافظه موقت GameManager
            if (starID == 1) GameManager.Instance.hasStar1 = true;
            else if (starID == 2) GameManager.Instance.hasStar2 = true;
            else if (starID == 3) GameManager.Instance.hasStar3 = true;

            GameManager.Instance.SaveCurrentMissionStars();

            if (finishesMission)
            {
                GameManager.Instance.ResetStars();
                SceneManager.LoadScene(mainSceneName);
            }

            Destroy(gameObject);
        }
    }
}