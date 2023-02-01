using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    [SerializeField]
    private int ammoInClip;
    [SerializeField]
    private int ammoAll;
    [SerializeField]
    private int ammoInClipCurrent;
    [SerializeField]
    private int ammoAllCurrent;
    [SerializeField]
    private float reloadDelay;
    [SerializeField]
    private bool onReload;

    private void Start()
    {
        WeaponManager.PICKAMMO += FillAmmo;
    }

    private void OnDestroy() {
        WeaponManager.PICKAMMO -= FillAmmo;    
    }

    private void OnEnable() {
        SendAmmoInfo();
    }

    private void OnDisable() {
        onReload = false;
    }

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
            if(Input.GetKeyDown(KeyCode.R)){
                if(ammoInClipCurrent < ammoInClip && ammoAllCurrent > 0)
                {
                    onReload = true;
                    WeaponManager.RELOAD?.Invoke(reloadDelay);
                    StartCoroutine(WaitForReloadDelay());
                }
            }
        }
    }

    public void FillAmmo(int count)
    {
        ammoAllCurrent += ammoAllCurrent + count <= ammoAll ? count : ammoAll - ammoAllCurrent;
        if(gameObject.activeSelf)
            SendAmmoInfo();
    }

    public void FillAmmo()
    {
        FillAmmo(ammoInClip);
    }

    private IEnumerator WaitForReloadDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        Reload();
    }

    public bool HasAmmo()
    {
        return ammoInClipCurrent > 0;
    }

    public bool IsFullAmmo()
    {
        return ammoAll == ammoAllCurrent;
    }

    public bool IsOnReload()
    {
        return onReload;
    }

    public void ShootBullet()
    {
        if(ammoInClipCurrent > 0) ammoInClipCurrent--;
        SendAmmoInfo();
    }

    private string GetInfoAboutAmmo()
    {
        return ammoInClipCurrent + "/" + ammoInClip + "\n" + ammoAllCurrent + "/" + ammoAll;
    }

    private void Reload()
    {
        int x = ammoAllCurrent - (ammoInClip - ammoInClipCurrent) >= 0? ammoInClip - ammoInClipCurrent : ammoAllCurrent;
        ammoInClipCurrent += x;
        ammoAllCurrent -= x;
        onReload = false;
        SendAmmoInfo();
    }

    private void SendAmmoInfo(){
        WeaponManager.EDITINFOABOUTAMMO?.Invoke(GetInfoAboutAmmo());
    }
}
