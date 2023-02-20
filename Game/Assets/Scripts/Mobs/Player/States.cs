using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player{
internal class States : MonoBehaviour
{
    [SerializeField, HideInInspector, Min(1)]
    private int level = 1;
    [SerializeField, Min(0)]
    private int XPMax;
    [SerializeField, Min(0)]
    private int XP;
    [SerializeField, Min(0)]
    private int HPMax;
    [SerializeField, Min(0)]
    private int HP;
    [SerializeField, Min(0)]
    private int staminaMax;
    [SerializeField, Min(0)]
    private int stamina;
    [SerializeField, Min(0)]
    private int restoreStamina; 
    [SerializeField, Min(0)]
    private int expendStamina;

    private void Start()
    {
        SendStates();
    }

    private void OnEnable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.run += ExpendStamina;
        c.walk += RestoreStamina;
        c.idle += RestoreStamina;
        c.heal += Heal;
        c.XPRise += GetXP;
        c.hurt += TakeDamage;
    }

    private void OnDisable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.run -= ExpendStamina;
        c.walk -= RestoreStamina;
        c.idle -= RestoreStamina;
        c.heal -= Heal;
        c.XPRise -= GetXP;
        c.hurt -= TakeDamage;
    }

    public bool IsItFullHP()
    {
        return HP >= HPMax;
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

    public bool IsItFullStamina()
    {
        return stamina >= staminaMax;
    }

    public bool HasStamina()
    {
        return stamina > 0;
    }

    private void GetXP(int x)
    {
        if(x < 0 ){return;}
        XP += x;
        if(XP >= XPMax)
        {
            LevelUP();
            XP-=XP;
            XPMax *= 2;
        }
        SendXPInfo();
    }

    private void LevelUP()
    {
        level++;
        SendLevelInfo();
    }

    private void TakeDamage(int x)
    {
        if(x<0 || !IsAlive()){return;}
        HP -= HP - x >=0? x : HP;
        SendHPInfo();
        if(!IsAlive())
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Player.Controller>().die?.Invoke();
    }

    private void Heal(int x)
    {
        if(x<0 || IsItFullHP()){return;}
        HP += HP + x <= HPMax? x : HPMax - HP;
        SendHPInfo();
    }

    private void ExpendStamina()
    {  
        if(!HasStamina()) {return;}
        stamina-= stamina - expendStamina >= 0 ? expendStamina : stamina;
        SendStaminaInfo();
    }

    internal void ExpendStamina(int x)
    {
        if(x<0 || !HasStamina()) {return;}
        stamina -= stamina >= x? x : stamina;
        SendStaminaInfo();
    }

    private void RestoreStamina()
    { 
        if(IsItFullStamina()) {return;}
        stamina += stamina + restoreStamina <= staminaMax ? restoreStamina : staminaMax - stamina;
        SendStaminaInfo();
    }

    private void SendStates()
    {
        SendLevelInfo();
        SendHPInfo();
        SendXPInfo();
        SendStaminaInfo();
    }

    private void SendLevelInfo()
    {
        GameUIManager.INFOLEVEL?.Invoke(level);
    }

    private void SendHPInfo()
    {
        GameUIManager.INFOHP?.Invoke(((float)HP)/HPMax);
    }

    private void SendXPInfo()
    {
        GameUIManager.INFOXP?.Invoke(((float)XP)/XPMax);
    }

    private void SendStaminaInfo()
    {
        GameUIManager.INFOSTAMINA?.Invoke(((float)stamina)/staminaMax);
    }
}
}