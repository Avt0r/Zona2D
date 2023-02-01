using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP133 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int parts;
    [SerializeField]
    private float accuracy;
    [SerializeField]
    private WeaponAmmo ammo;

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
            if(Input.GetMouseButtonDown(0))
            {  
                if(/*anim.GetBool("canShot") &&*/ ammo.HasAmmo() && !ammo.IsOnReload())
                { 
                    // StartShot();
                    MakeShot();
                }
            }
        }
    }

    private void Wait()
    {
        anim.SetBool("canShot",true);
    }

    private void StartShot()
    {
        anim.SetBool("canShot",false);
    }

    private void MakeShot()
    {
        Bullet b = bullet.GetComponent<Bullet>();
            b.setDamage(damage);
        for(int i = 0; i < parts; i++)
        {
            Instantiate(b, shotPoint.position, transform.rotation).transform.Rotate(0, 0, Random.Range(-accuracy, accuracy+1), Space.Self);
        }
        
        ammo.ShootBullet();
    }
}
