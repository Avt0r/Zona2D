using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Makarov : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private Transform ptransform;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private int ammoMax;
    [SerializeField]
    private int ammoFull;
    [SerializeField]
    private int ammoCurrent;
    [SerializeField]
    private int ammoAllCurrent;

    [SerializeField]
    private int damage;

    [SerializeField] 
    private Text ammoCount;

    private void Start() {
        ammoCurrent = ammoMax;    
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {  
            if(anim.GetBool("canShot") && HasBullets())
            { 
                StartShot();
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
        
        ammoCount.text = ammoCurrent + "/" + ammoMax + "  " + ammoAllCurrent + "/" + ammoFull;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<AmmoBox>()){
        ammoAllCurrent += 15;
        Destroy(other.gameObject);
        }
    }

    private void Reload(){
        if(ammoCurrent == ammoMax || ammoAllCurrent <= 0){
            return;
        }
        int reloadNumber = ammoAllCurrent - (ammoMax - ammoCurrent) >= 0? ammoMax - ammoCurrent : ammoAllCurrent;
        ammoCurrent += reloadNumber;
        ammoAllCurrent -=reloadNumber;
    }

    private bool HasBullets(){
        return ammoCurrent > 0;
    }

    private void Wait()
    {
        Debug.Log("wait");
        anim.SetBool("canShot",true);
    }

    private void StartShot()
    {
        Debug.Log("shot");
        anim.SetBool("canShot",false);
    }

    private void MakeShot()
    {
        Bullet b = bullet.GetComponent<Bullet>();
        b.setDamage(damage);
        Instantiate(bullet, shotPoint.position, transform.rotation);
        ammoCurrent--;
    }

    private void LogShot()
    {
        Debug.Log("Log shot");
    }
}
