using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private int attackDelay;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(anim.GetBool("dealDamage")){
            other.GetComponent<Player>().ChangeHealth(-damage);
            anim.SetBool("dealDamage", false);
        }
        if(other.GetComponent<Player>())
        {   
            anim.SetBool("canAttack",true);
            StartCoroutine(Delay());
        }
    }
    
    private IEnumerator Delay()
    {            
        yield return new WaitForSeconds(attackDelay);
        anim.SetBool("canAttack", false);
    }

    private void DealDamage()
    {
        anim.SetBool("dealDamage", true);
    }
}
