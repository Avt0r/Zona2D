using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP133 : MonoBehaviour
{
    
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
    [SerializeField]
    private GameObject bullet;

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
            if(Input.GetMouseButtonDown(0))
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
        for(int i = 0; i < parts; i++)
        {
            GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
            b.GetComponent<Bullet>().SetDamage(damage);
            b.transform.Rotate(0,0,Random.Range(-accuracy, accuracy+1));
        }
        
        ammo.ShootBullet();
    }
}
