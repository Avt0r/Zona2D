using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Text ammoInfo;
    [SerializeField]
    private Reload reload;
    [SerializeField]
    private GameObject [] weapons;

    private void Start() {
        InitializeWeapons();
    }

    private void InitializeWeapons()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            Instantiate(weapons[i], transform.position, transform.rotation).transform.SetParent(transform);
        }
        
        foreach(Transform weapon in transform) {
            weapon.gameObject.SetActive(false);   
        }

        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnEnable() {
        WeaponManager.EDITINFOABOUTAMMO += AmmoInfoUpdate;
        WeaponManager.RELOAD += ReloadWeapon;
    }

    private void OnDisable() {
        WeaponManager.EDITINFOABOUTAMMO -= AmmoInfoUpdate;
        WeaponManager.RELOAD -= ReloadWeapon;
    }

    private void AmmoInfoUpdate(string text)
    {
        ammoInfo.text = text;
    }

    private void ReloadWeapon(float delay)
    {
        reload.ReloadStart(delay);
    }

}
