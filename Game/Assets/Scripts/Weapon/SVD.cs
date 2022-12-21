using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVD : MonoBehaviour
{

    public GameObject bullet;
    public Transform shotPoint;
    public Transform ptransform;
    public Animator anim;

    public int ammoMax;
    public int ammoFull;
    private int ammoCurrent;
    private int ammoAllCurrent;

    public int damage;

    [SerializeField] 
    private Text ammoCount;

    private void Start() {
        ammoCurrent = ammoMax;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 100f, Color.red);
        Physics.Raycast(ray);

        if(Input.GetMouseButton(0))
        {  
            if(anim.GetBool("canShot"))
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

    public void Reload(){
        if(ammoCurrent == ammoMax || ammoAllCurrent <= 0){
            return;
        }
        int reloadNumber = ammoAllCurrent - (ammoMax - ammoCurrent) >= 0? ammoMax - ammoCurrent : ammoAllCurrent;
        ammoCurrent += reloadNumber;
        ammoAllCurrent -=reloadNumber;
    }

    public bool HasBullets(){
        return ammoCurrent > 0;
    }

    public void Wait()
    {
        Debug.Log("wait");
        anim.SetBool("canShot",true);
    }

    public void StartShot()
    {
        Debug.Log("shot");
        anim.SetBool("canShot",false);
    }

    public void MakeShot()
    {
        Bullet b = bullet.GetComponent<Bullet>();
        b.setDamage(damage);
        Instantiate(b, shotPoint.position, transform.rotation);
        ammoCurrent--;
    }

    public void LogShot()
    {
        Debug.Log("Log shot");
    }
}
