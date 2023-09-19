using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
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
    private LayerMask target;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private Text ammoCount;

    private void Update() { 
        if(reloaded) 
            if(Input.GetMouseButton(0))
            {
                anim.Play("Attack"); 
                reloaded = false; 
            }
    }

    private void OnEnable() {
        GameUIManager.INFOAMMO?.Invoke("Inf");
    }

    private void Reload()
    {
        reloaded = true;
    }

    private void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, target);
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
