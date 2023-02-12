using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVD : MonoBehaviour
{
    
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private int damage;
    [SerializeField]
    private WeaponAmmo ammo;
    [SerializeField]
    private GameObject bullet;

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
        GetComponent<WeaponAudio>().PlayShot();
    }

    private void MakeShot()
    {
        GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
        b.GetComponent<Bullet>().SetDamage(damage);
        ammo.ShootBullet();
    }
}
