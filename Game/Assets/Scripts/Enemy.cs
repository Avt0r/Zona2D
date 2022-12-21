using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    private void Update()
    {   
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        moveVector.x = Target.position.x - transform.position.x;
        moveVector.y = Target.position.y - transform.position.y;

        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
