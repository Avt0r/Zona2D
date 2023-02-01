using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVD : MonoBehaviour
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
    private WeaponAmmo ammo;

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
            if(Input.GetMouseButton(0))
            {  
                if(anim.GetBool("canShot") && ammo.HasAmmo() && !ammo.IsOnReload())
                { 
                    StartShot();
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
        Instantiate(b, shotPoint.position, transform.rotation);
        ammo.ShootBullet();
    }
}
