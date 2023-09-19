using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _children;
    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _equipment;
    [SerializeField]
    public Func<int> getEquipmentNum;

    private void Awake()
    {
        _children = new Transform[transform.childCount];
        WriteAllChildren();
        HideAllChildren();
        _children[0].gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowEquipment()
    {
        HideAllChildren();
        _equipment.SetActive(true);
    }

    public void ShowMainMenu()
    {
        HideAllChildren();
        _mainMenu.SetActive(true);
    }

    public void WriteMainMenu(GameObject mainMenu)
    {
        _mainMenu = mainMenu;
        ShowMainMenu();
    }

    public void WriteEquipment(GameObject equipment) 
    {
        _equipment = equipment;
    }

    public void ShowChild(int x)
    {
        HideAllChildren();
        _children[x].gameObject.SetActive(true);
    }

    private void WriteAllChildren()
    {
        for(int i=0; i < transform.childCount; i++)
        {
            _children[i]= transform.GetChild(i);
        }
    }

    private void HideAllChildren()
    {
        foreach(Transform i in _children)
        {
            i.gameObject.SetActive(false);
        }
    }
}
