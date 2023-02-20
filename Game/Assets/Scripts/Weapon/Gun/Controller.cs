using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Gun
{
    [RequireComponent(typeof(ShotManager))]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        internal Properties properties;
        [SerializeField, HideInInspector]
        private int ammoInClipCurrent;
        [SerializeField, HideInInspector]
        private int ammoAllCurrent;
        [SerializeField, HideInInspector]
        private bool readyToShot;
        [SerializeField, HideInInspector]
        private bool onReload;
        internal Action shot;
        internal Action makeShot;
        internal Action idle;
        internal Action reloadStart;
        internal Action reloadStop;
        internal Action<string> ammoInfo;

        private void Awake()
        {
            WeaponManager.PICKAMMO += FillAmmo;
            ammoInClipCurrent = properties.AmmoInClip;
            ammoAllCurrent = 0;
            Ready();
            onReload = false;
        }

        private void OnEnable()
        {
            ShotManager s = GetComponent<ShotManager>();
            s.makeShot += Shot;
            SendAmmoInfo();
        }

        private void OnDisable()
        {
            ShotManager s = GetComponent<ShotManager>();
            s.makeShot -= Shot;
            Ready();
            onReload = false;
        }

        private void OnDestroy()
        {
            WeaponManager.PICKAMMO -= FillAmmo;
        }

        private void Update()
        {
            if (!PauseMenu.GAMEISPAUSED)
            {
                CheckFireButton();
                CheckReloadButton();
            }
        }

        private void CheckFireButton()
        {
            if (Input.GetMouseButton(0) && CanShot())
            {
                shot?.Invoke();
            }
        }

        private void CheckReloadButton()
        {
            if (Input.GetKey(KeyCode.R) && HasExtraAmmo() && !IsFullAmmo() && !onReload)
            {
                StartCoroutine(WaitForReloadDelay());
            }
        }

        private IEnumerator WaitForReloadDelay()
        {
            DontReady();
            onReload = true;
            reloadStart?.Invoke();
            yield return new WaitForSeconds(properties.ReloadDelay);
            reloadStop?.Invoke();
            Reload();
            Ready();
            SendAmmoInfo();
            onReload = false;
        }

        private void Reload()
        {
            int dif = properties.AmmoInClip - ammoInClipCurrent;
            dif = ammoAllCurrent > dif ? dif : ammoAllCurrent;
            if (dif > 0)
            {
                ammoInClipCurrent += dif;
                ammoAllCurrent -= dif;
            }
        }

        private void Idle()
        {
            idle?.Invoke();
        }

        private bool CanShot()
        {
            return readyToShot && HasAmmo() && !onReload;
        }

        private bool IsFullAmmo()
        {
            return ammoInClipCurrent == properties.AmmoInClip;
        }

        private bool HasAmmo()
        {
            return ammoInClipCurrent > 0;
        }

        private bool HasExtraAmmo()
        {
            return ammoAllCurrent > 0;
        }

        private void FillAmmo()
        {
            ammoAllCurrent += properties.AmmoInClip + ammoAllCurrent <= properties.AmmoAll ?
                properties.AmmoInClip : properties.AmmoAll - ammoAllCurrent;
            if (gameObject.activeInHierarchy)
                SendAmmoInfo();
        }

        private void Shot()
        {
            ammoInClipCurrent--;
            SendAmmoInfo();
        }

        private void SendAmmoInfo()
        {
            ammoInfo?.Invoke(GetAmmoInfo());
        }

        private string GetAmmoInfo()
        {
            return (ammoInClipCurrent + "/" + properties.AmmoInClip + "\n" +
                ammoAllCurrent + "/" + properties.AmmoAll);
        }

        private void Ready()
        {
            readyToShot = true;
        }

        private void DontReady()
        {
            readyToShot = false;
        }
    }
}