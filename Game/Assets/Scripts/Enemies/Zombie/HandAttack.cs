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
    [SerializeField]
    private bool inRadius;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.tag == "Player")
        {
            inRadius = true;
            StartCoroutine(StartAttacking());
        }
    }

    private IEnumerator StartAttacking()
    {
        yield return new WaitForSeconds(0.5f);
        anim.Play("HandAttack");
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            inRadius = false;
            Idle();
            StopCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {            
        yield return new WaitForSeconds(attackDelay);
        if(inRadius)
        anim.Play("HandAttack");
    }

    private void DealDamage()
    {
        if(inRadius){
        player.ChangeHealth(-damage);
        StartCoroutine(Delay());
        }
    }

    private void Idle()
    {
        anim.Play("HandIdle");
    }
}