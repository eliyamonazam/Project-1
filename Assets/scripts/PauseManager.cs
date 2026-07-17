using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
   public GameObject pausePanel;
    public GameObject settingsPanel;

    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    void Update()
    {
          if(Input.GetKeyDown(KeyCode.Escape))
    {
        if(Time.timeScale == 1)
        {
            Pause();
        }
    }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
