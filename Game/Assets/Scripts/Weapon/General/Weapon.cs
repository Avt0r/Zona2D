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
    private CircleCollider2D collider;

    private void OnEnable() {
        WeaponManager.EDITINFOABOUTAMMO += AmmoUnfoUpdate;
        WeaponManager.RELOAD += ReloadWeapon;
    }

    private void OnDisable() {
        WeaponManager.EDITINFOABOUTAMMO -= AmmoUnfoUpdate;
        WeaponManager.RELOAD -= ReloadWeapon;
    }

    private void AmmoUnfoUpdate(string text)
    {
        ammoInfo.text = text;
    }

    private void ReloadWeapon(float delay)
    {
        reload.ReloadStart(delay);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ammo")
        {
            WeaponManager.PICKAMMO?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
