using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    
    public GameObject Panel;


    public void GameOver()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
