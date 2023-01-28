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

    [SerializeField]
    private Reload reload;

    [SerializeField]
    private float delay;

    private void Start() {
        ammoCurrent = ammoMax;
    }

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
        if(Input.GetMouseButton(0))
        {  
            if(anim.GetBool("canShot") && HasBullets())
            { 
                StartShot();
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            ReloadStart();
        }

        ammoCount.text = ammoCurrent + "/" + ammoMax + "\n" + ammoAllCurrent + "/" + ammoFull;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<AmmoBox>() && !IfAmmoIsFull()){
        FillAmmo(15);
        Destroy(other.gameObject);
        }
    }

    private bool IfAmmoIsFull()
    {
        return ammoAllCurrent == ammoFull;
    }

    private void FillAmmo(int num)
    {
        ammoAllCurrent += ammoAllCurrent + num <= ammoFull? num : ammoFull - ammoAllCurrent ;
    }

    private void ReloadStart(){
        if(ammoCurrent == ammoMax || ammoAllCurrent <= 0){
            return;
        }
        reload.ReloadStart(delay);
        StartCoroutine(WaitForFinishReload());
    }

    private IEnumerator WaitForFinishReload()
    {
        while(true)
        {
            yield return null;
            if(reload.IsReloadFinished())
            {
                ReloadFinish(); 
                break;
            }
        }
    }

    private void ReloadFinish()
    {
        int reloadNumber = ammoAllCurrent - (ammoMax - ammoCurrent) >= 0? ammoMax - ammoCurrent : ammoAllCurrent;
        ammoCurrent += reloadNumber;
        ammoAllCurrent -=reloadNumber;
    }

    private bool HasBullets(){
        return ammoCurrent > 0;
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
        ammoCurrent--;
    }
}
