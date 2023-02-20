using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Gun
{
    internal class ShotManager : MonoBehaviour
    {
        [SerializeField]
        private Bullet bullet;
        [SerializeField, HideInInspector]
        private Transform shotPoint;
        internal Action makeShot;

        private void Awake()
        {
            shotPoint = this.transform.GetChild(0);
        }

        private void MakeShot()
        {
            Controller c = GetComponent<Controller>();
            makeShot?.Invoke();
            if (c.properties.Parts > 1)
            {
                for( int i = 0; i < c.properties.Parts; i++)
                {
                    Bullet b = Instantiate(bullet, shotPoint.position, transform.rotation);
                    b.SetDamage(c.properties.Damage);
                    b.Rotate(0,0,UnityEngine.Random.Range(-c.properties.Accurancy, c.properties.Accurancy+1));
                }
            }
            else
            {
                Bullet b = Instantiate(bullet, shotPoint.position, transform.rotation);
                b.SetDamage(c.properties.Damage);
            }
        }
    }
}
