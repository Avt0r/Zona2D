using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{   

    private void Start() {
        gameObject.SetActive(false);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
