using Gun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Character
{
    internal class States : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        Controller controller;
        [SerializeField, HideInInspector, Min(1)]
        private int level = 1;
        [SerializeField, Min(0),]
        private int xpMax;
        [SerializeField, Min(0)]
        private int xp;
        [SerializeField, Min(0)]
        private int hpMax;
        [SerializeField, Min(0)]
        private int hp;
        [SerializeField, Min(0)]
        private int spMax;
        [SerializeField, Min(0)]
        private int sp;
        [SerializeField, Min(0)]
        private int restoreSP;
        [SerializeField, Min(0)]
        private int expendSP;

        private void Awake()
        {
            controller = GetComponent<Controller>();
        }

        private void OnEnable()
        {
            controller.run += ExpendStamina;
            controller.walk += RestoreStamina;
            controller.idle += RestoreStamina;
            controller.heal += Heal;
            controller.xpRise += RiseXp;
            controller.hurt += TakeDamage;
        }

        private void OnDisable()
        {
            controller.run -= ExpendStamina;
            controller.walk -= RestoreStamina;
            controller.idle -= RestoreStamina;
            controller.heal -= Heal;
            controller.xpRise -= RiseXp;
            controller.hurt -= TakeDamage;
        }

        internal int Level { get { return level; } }
        internal float XPNormalized { get { return ((float)xp) / xpMax; } }
        internal float HPNormalized { get { return ((float)hp) / hpMax; } }
        internal float SPNormalized { get { return ((float)sp) / spMax; } }

        internal bool IsItFullHP()
        {
            return hp >= hpMax;
        }

        internal bool IsAlive()
        {
            return hp > 0;
        }

        internal bool IsItFullStamina()
        {
            return sp >= spMax;
        }

        internal bool HasStamina()
        {
            return sp > 0;
        }

        internal void RiseXp(int x)
        {
            if (x < 0) { return; }
            xp += x;
            while (xp >= xpMax)
            { 
                LevelUp();
            }
            controller.xpChange?.Invoke();
        }

        private void LevelUp()
        {
            level++;
            controller.levelUp?.Invoke();
            xp -= xp;
            xpMax *= 2;
        }

        private void TakeDamage(int x)
        {
            if (x < 0 || !IsAlive()) { return; }
            hp -= hp - x >= 0 ? x : hp;
            controller.hpChange?.Invoke();
            if (!IsAlive())
            {
                Die();
            }
        }

        private void Die()
        {
            controller.die?.Invoke();
        }

        private void Heal(int x)
        {
            if (x < 0 || IsItFullHP()) { return; }
            hp += hp + x <= hpMax ? x : hpMax - hp;
            controller.hpChange?.Invoke();
        }

        private void ExpendStamina()
        {
            if (!HasStamina()) { return; }
            sp -= sp - expendSP >= 0 ? expendSP : sp;
            controller.spChange?.Invoke();
        }

        private void RestoreStamina()
        {
            if (IsItFullStamina()) { return; }
            sp += sp + restoreSP <= spMax ? restoreSP : spMax - sp;
            controller.spChange?.Invoke();
        }
    }
}