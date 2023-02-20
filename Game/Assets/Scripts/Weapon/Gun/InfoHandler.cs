using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(Controller))]
    internal class InfoHandler : MonoBehaviour
    {

        private void Awake()
        {
            Controller c = GetComponent<Controller>();
            c.ammoInfo += SendAmmoInfo;
        }

        private void OnDestroy()
        {
            Controller c = GetComponent<Controller>();
            c.ammoInfo -= SendAmmoInfo;
        }

        private void SendAmmoInfo(string info)
        {
            GameUIManager.INFOAMMO?.Invoke(info);
        }
    }
}