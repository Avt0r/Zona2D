using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStates : MonoBehaviour
{
    [SerializeField]
    private Text level;
    [SerializeField]
    private Image xp;
    [SerializeField]
    private Image hp;
    [SerializeField]
    private Image stamina;
    [SerializeField]
    private Text ammo;
    [SerializeField]
    private ReloadAnim.Controller _reload;

    private void OnEnable() {
        GameUIManager.INFOLEVEL += SendLevel;
        GameUIManager.INFOXP += SendXP;
        GameUIManager.INFOHP += SendHP;
        GameUIManager.INFOSTAMINA += SendStamina;
        GameUIManager.INFOAMMO += SendAmmo;
        GameUIManager.RELOADSTART += ReloadStart;
        GameUIManager.RELOADSTOP += ReloadStop;
    }

    private void OnDisable() {
        GameUIManager.INFOLEVEL -= SendLevel;
        GameUIManager.INFOXP -= SendXP;
        GameUIManager.INFOHP -= SendHP;
        GameUIManager.INFOSTAMINA -= SendStamina;
        GameUIManager.INFOAMMO -= SendAmmo;
        GameUIManager.RELOADSTART -= ReloadStart;
        GameUIManager.RELOADSTOP -= ReloadStop; 
    }

    private void SendLevel(int x)
    {
        level.text = x + "";
    }

    private void SendXP(float x)
    {
        xp.fillAmount = x;
    }

    private void SendHP(float x)
    {
        hp.fillAmount = x;
    }

    private void SendStamina(float x)
    {
        stamina.fillAmount = x;
    }

    private void SendAmmo(string s)
    {
        ammo.text = s;
    }

    private void ReloadStart()
    {
        _reload.StartAnimation();
    }

    private void ReloadStop()
    {
        _reload.StopAnimation();
    }
}
