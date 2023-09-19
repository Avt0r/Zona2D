using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunComponents
{
    [CreateAssetMenu(fileName = "Properies", menuName = "Weapon", order = 51)]
    internal class Properties : ScriptableObject
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private float rate;
        [SerializeField]
        private int penetration;
        [SerializeField]
        private int accuracy;
        [SerializeField]
        private int ammoInClip;
        [SerializeField]
        private int ammoAll;
        [SerializeField]
        private float reloadDelay;
        [SerializeField]
        private int parts;

        public int Damage
        { get { return damage; } }
        public float Rate
        { get { return rate; } }
        public int Penetration
        { get { return penetration; } }
        public int Accurancy
        { get { return accuracy; } }
        public int AmmoInClip
        { get { return ammoInClip; } }
        public int AmmoAll
        { get { return ammoAll; } }
        public float ReloadDelay
        { get { return reloadDelay; } }
        public int Parts
        { get { return parts; } }
    }
}