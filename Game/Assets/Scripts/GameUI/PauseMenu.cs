using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GAMEISPAUSED = false;
    public GameObject pauseMenuUI;

    private void Start() {
       Resume(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GAMEISPAUSED)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GAMEISPAUSED = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GAMEISPAUSED = true;
    }
}
