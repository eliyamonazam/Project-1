using UnityEngine;

public class SaveLoadUIHelper : MonoBehaviour
{
    
    public void ClickSaveButton()
    {
        if (GameManager.Instance != null)
        {
            float knightHP = 100f; 
            float fairyHP = 100f;  

            GameManager.Instance.SaveGame(knightHP, fairyHP);
            Debug.Log("درخواست ذخیره بازی به GameManager فرستاده شد.");
        }
        else
        {
            Debug.LogError("GameManager در صحنه پیدا نشد!");
        }
    }

    public void ClickLoadButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadGame();
            Debug.Log("درخواست بارگذاری بازی به GameManager فرستاده شد.");
        }
        else
        {
            Debug.LogError("GameManager در صحنه پیدا نشد!");
        }
    }
}