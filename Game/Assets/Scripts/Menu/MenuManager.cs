using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject inventoryMenu;

    private void Start() {
        ShowMainMenu();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowInevntoryMenu()
    {
        mainMenu.SetActive(false);
        inventoryMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        inventoryMenu.SetActive(false);
    }
}
