using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{   
    [SerializeField]
    private int healtMax;
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int XPCount;
    [SerializeField, HideInInspector]
    private Transform target;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField, HideInInspector]
    private Vector2 moveVector; 
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image healthLowBar;
    [SerializeField, HideInInspector]
    private Canvas canvas;
    [SerializeField]
    private Drop [] dropItems;
    [SerializeField]
    private XP XPObject;
    [SerializeField]
    private int dropChance;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private GameObject deathEffect;

    private void Awake()
    {
       canvas.worldCamera = Camera.main; 
    }

    private void Start() {
       HealthBarHide();
       XPObject.SetCount(XPCount);
    }

    private void FixedUpdate() { 
        moveVector.x = target.position.x - transform.position.x;
        moveVector.y = target.position.y - transform.position.y;

        Scale();
        StopWhenNearToPlayer();
    }

    private void StopWhenNearToPlayer()
    {
        if(moveVector.magnitude > minDistance)
        {
        rb.velocity = moveVector.normalized * speed;
        }else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    private void Scale(){
        if(moveVector.x > 0.01f)
        {
            healthBar.transform.localScale = new Vector3(Mathf.Abs(healthBar.transform.localScale.x), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            healthLowBar.transform.localScale = new Vector3(Mathf.Abs(healthLowBar.transform.localScale.x), healthLowBar.transform.localScale.y, healthLowBar.transform.localScale.z);  
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if(moveVector.x < 0.01f)
        {
            healthBar.transform.localScale = new Vector3(-Mathf.Abs(healthBar.transform.localScale.x), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            healthLowBar.transform.localScale = new Vector3(-Mathf.Abs(healthLowBar.transform.localScale.x), healthLowBar.transform.localScale.y, healthLowBar.transform.localScale.z);    
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } 
    }

    public void TakeDamage(int damage)
    {
        if(health <=0 )
        {
            return;
        }
        HealthBarShow();
        health -= damage;
        healthBar.fillAmount = ((float)health) / healtMax;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die(){
        DropSpawn();
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void DropSpawn(){
        Instantiate(XPObject, transform.position, Quaternion.identity);
        if(Random.Range(0,101)<=dropChance)
        {   
            Drop drop = Drop.ReturnDropFromArray(dropItems);
            Instantiate(drop.ReturnDropObject(), transform.position, Quaternion.identity);
        }
    }

    private void HealthBarShow(){
        healthBar.enabled = true;
        healthLowBar.enabled = true;
    }

    private void HealthBarHide(){
        healthBar.enabled = false;
        healthLowBar.enabled = false;
    }
}
