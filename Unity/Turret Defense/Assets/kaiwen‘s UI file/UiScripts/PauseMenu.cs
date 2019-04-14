using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PausePanel;

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
      
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
