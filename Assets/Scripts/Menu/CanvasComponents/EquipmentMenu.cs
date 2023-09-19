using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : MonoBehaviour
{
    [SerializeField]
    private MenuManager _parent;

    private void Awake()
    {
        _parent = transform.parent.GetComponent<MenuManager>();
        _parent.getEquipmentNum += GetMyNum;
    }

    private void OnDestroy()
    {
        _parent.getEquipmentNum -= GetMyNum;
    }

    private int GetMyNum()
    {
        return transform.GetSiblingIndex();
    }
}
