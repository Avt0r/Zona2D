using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonSlayer : MonoBehaviour
{
     [SerializeField]
    private int damage;
    [SerializeField]
    private float delay;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool reloaded;
    [SerializeField]
    private LayerMask enemy;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private Text ammoCount;

    private void Update() { 
        ammoCount.text = "Inf";  
        if(reloaded) 
            if(Input.GetMouseButton(0))
            {
                anim.Play("Attack"); 
                reloaded = false; 
            }
    }

    private void Reload()
    {
        reloaded = true;
    }

    private void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemy);
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void Idle()
    {
        anim.Play("Idle");  
    }
}
