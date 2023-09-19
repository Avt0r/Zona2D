using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace CharacterComponents
{
    [RequireComponent(typeof(CharacterController))]
    internal class InfoHandler : MonoBehaviour
    {

        [SerializeField, HideInInspector]
        private CharacterController c;

        private void Awake()
        {
            c = GetComponent<CharacterController>();
        }

        private void Start()
        {
            UpdateStates(); 
        }

        private void OnEnable()
        {
            c.die += ShowDeathScreen;
            c.spChange += UpdateSP;
            c.hpChange += UpdateHP;
            c.xpChange += UpdateXP;
            c.levelUp += UpdateLevel;
            c.openCloseInventory += OpenCloseInventory;
        }

        private void OnDisable()
        {
            c.die -= ShowDeathScreen;
            c.spChange -= UpdateSP;
            c.hpChange -= UpdateHP;
            c.xpChange -= UpdateXP;
            c.levelUp -= UpdateLevel; 
            c.openCloseInventory -= OpenCloseInventory;
        }

        private void OpenCloseInventory()
        {
            GameUIManager.SHOWHIDEINVENTORY?.Invoke();
        }

        private void ShowDeathScreen()
        {
            GameUIManager.SHOWDEATHSCREEN?.Invoke();
        }

        private void UpdateStates()
        {
            UpdateHP();
            UpdateSP();
            UpdateXP();
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            GameUIManager.INFOLEVEL?.Invoke(c.states.Level);
        }

        private void UpdateHP()
        {
            GameUIManager.INFOHP?.Invoke(c.states.HPNormalized);
        }

        private void UpdateXP()
        {
            GameUIManager.INFOXP?.Invoke(c.states.XPNormalized);
        }

        private void UpdateSP()
        {
            GameUIManager.INFOSTAMINA?.Invoke(c.states.SPNormalized);
        }
    }
}
