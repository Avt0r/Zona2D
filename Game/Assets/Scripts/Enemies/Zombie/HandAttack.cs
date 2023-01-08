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
    [SerializeField]
    private Player player;
    
    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.tag == "Player")
        {
            anim.SetBool("canAttack", true);
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            anim.SetBool("canAttack", false);
        }
    }

    private IEnumerator Delay()
    {            
        yield return new WaitForSeconds(attackDelay);
        anim.SetBool("canAttack", true);
    }

    private void DealDamage()
    {
        player.ChangeHealth(-damage);
        anim.SetBool("canAttack", false);
        StartCoroutine(Delay());
    }
}
