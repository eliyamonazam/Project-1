using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("sara's wef"); 
    }
    public void OpenStore()
    {
        SceneManager.LoadScene("Store"); 
    }
    public void QuitGame()
    {
        Debug.Log("Game closed !"); 
        Application.Quit(); 
    }
}