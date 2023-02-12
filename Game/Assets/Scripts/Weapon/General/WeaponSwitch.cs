using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private int weaponSwitch = 0;
    [SerializeField, HideInInspector]
    private bool cd;

    private void Start()
    {
        SelectWeapon();
        cd=true;
    }

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED && cd){
        int currentWeapon = weaponSwitch;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            PlaySound();
            if(weaponSwitch >= transform.childCount -1)
            {
                weaponSwitch = 0;
            }
            else
            {
                weaponSwitch++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            PlaySound();
            if(weaponSwitch <= 0)
            {
                weaponSwitch = transform.childCount - 1;
            }
            else
            {
                weaponSwitch--;
            }
        }

        if(currentWeapon != weaponSwitch)
        {
            SelectWeapon();
            StartCoroutine(WaitForSwitchCooldown());
        }
        }
    }

    private IEnumerator WaitForSwitchCooldown()
    {
        cd = false;
        yield return new WaitForSeconds(0.3f);
        cd = true;
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform) {
            if(i == weaponSwitch)
               { weapon.gameObject.SetActive(true);
               }
            else
            {
                weapon.gameObject.SetActive(false);
            }    
            i++;
        }
    }
}
