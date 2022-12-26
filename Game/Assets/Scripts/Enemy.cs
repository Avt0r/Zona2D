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
    private Transform Target;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveVector; 
    [SerializeField]
    private Image healtBar;
    private void Start() {
       
    }

    private void FixedUpdate() { 
        moveVector.x = Target.position.x - transform.position.x;
        moveVector.y = Target.position.y - transform.position.y;
   
        rb.MovePosition(rb.position + moveVector * speed * 0.01f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healtBar.fillAmount = ((float)health) / healtMax;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
