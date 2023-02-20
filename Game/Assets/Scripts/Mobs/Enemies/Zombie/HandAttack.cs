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
    private int delayBeforeAttack;
    [SerializeField, HideInInspector]
    private Collider2D target;

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.CompareTag("Player"))
        {
            target = other;
            StartCoroutine(StartAttacking());
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            target = null;
            StopCoroutine(StartAttacking());
            Idle();
        }
    }

    private IEnumerator StartAttacking()
    {   
        Idle();
        yield return new WaitForSeconds(delayBeforeAttack);
        if(target != null) {anim.Play("HandAttack");}
        else {Idle();}
    }

    private void DealDamage()
    {
        target?.GetComponent<Player.Controller>().hurt?.Invoke(damage);
    }

    private void Idle()
    {
        anim.Play("HandIdle");
    }
}