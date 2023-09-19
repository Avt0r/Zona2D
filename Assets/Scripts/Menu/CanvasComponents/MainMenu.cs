using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private MenuManager _parent;
    [SerializeField]
    private int _equipmentNum;
 
    private void Awake()
    {
        _parent = transform.parent.GetComponent<MenuManager>();
    }

    private void Start()
    {
        _equipmentNum = _parent.getEquipmentNum();
    }

    public void Play()
    {
        _parent.StartGame();
        
    }

    public void ChooseEquipment()
    {
        _parent.ShowChild(_equipmentNum);
    }

    private int GetMyNum()
    {
        return transform.GetSiblingIndex();
    }
}
