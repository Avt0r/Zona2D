using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Text _ammoInfo;
    [SerializeField]
    private GameObject _primaryWeapon;
    [SerializeField]
    private GameObject _secondaryWeapon;
    [SerializeField]
    private Transform _primaryWeaponLink;
    [SerializeField] 
    private Transform _secondaryWeaponLink;

    private void Start() {
        //_primaryWeapon = EquipmentTransfer.SELECTEDWEAPONPRIMARY;
        //_secondaryWeapon = EquipmentTransfer.SELECTEDWEAPONSECONDARY;
        InitializeWeapons();
    }

    private void InitializeWeapons()
    {
        Instantiate(_primaryWeapon, transform.position, transform.rotation).transform.SetParent(transform);
        Instantiate(_secondaryWeapon, transform.position, transform.rotation).transform.SetParent(transform);

        _primaryWeaponLink = transform.GetChild(0);
        _secondaryWeaponLink = transform.GetChild(1);

        _primaryWeaponLink.gameObject.SetActive(true);
        _secondaryWeaponLink.gameObject.SetActive(false);

    }

    private void OnEnable() {
        GameUIManager.INFOAMMO += AmmoInfoUpdate;
    }

    private void OnDisable() {
        GameUIManager.INFOAMMO -= AmmoInfoUpdate;
    }

    private void AmmoInfoUpdate(string text)
    {
        _ammoInfo.text = text;
    }

}
