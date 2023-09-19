using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private void Start() {
       Resume(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(TimeManager.TIMEISSTOPPED)
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
        TimeManager.ResumeTime();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        TimeManager.StopTime();
    }
}
