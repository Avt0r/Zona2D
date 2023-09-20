using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{   
    [SerializeField]
    private GameObject ui;

    private void Awake() {
        GameUIManager.SHOWDEATHSCREEN += Show;
    }

    private void OnDestroy() {
        GameUIManager.SHOWDEATHSCREEN -= Show;
    }

    private void Start() {
        ui.SetActive(false);
    }

    private void OnDisable() {
        ResumeTime();    
    }

    private void Show()
    {
        ui.SetActive(true);
        TimeManager.StopTime();
    }

    public void ResumeTime()
    {
        TimeManager.ResumeTime();
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