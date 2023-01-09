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
    private Transform target;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveVector; 
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image healthLowBar;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject [] dropItems;
    [SerializeField]
    private int dropChance;

    private void Start() {
       GameObject player = GameObject.FindGameObjectWithTag("Player");
       target = player.transform;
       canvas.worldCamera = Camera.main;
       HealthBarHide();
    }

    private void FixedUpdate() { 
        moveVector.x = target.position.x - transform.position.x;
        moveVector.y = target.position.y - transform.position.y;
    
        Scale();

        rb.MovePosition(rb.position + moveVector * speed * 0.01f);
    }

    private void Scale(){
        if(moveVector.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if(moveVector.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } 
    }

    public void TakeDamage(int damage)
    {
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
        Destroy(gameObject);
    }

    private void DropSpawn(){
        if(Random.Range(0,101)<=dropChance)
        {
            int itemId = Random.Range(0,dropItems.Length);
            Instantiate(dropItems[itemId], transform.position, Quaternion.identity);
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
