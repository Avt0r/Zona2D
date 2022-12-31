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
    
    private void Start() {
       GameObject player = GameObject.FindGameObjectWithTag("Player");
       target = player.transform;
       canvas.worldCamera = Camera.main;
       healthBar.enabled = false;
       healthLowBar.enabled = false;
    }

    private void FixedUpdate() { 
        moveVector.x = target.position.x - transform.position.x;
        moveVector.y = target.position.y - transform.position.y;
    
        if(moveVector.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if(moveVector.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        rb.MovePosition(rb.position + moveVector * speed * 0.01f);
    }

    public void TakeDamage(int damage)
    {
        healthBar.enabled = true;
        healthLowBar.enabled = true;
        health -= damage;
        healthBar.fillAmount = ((float)health) / healtMax;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
