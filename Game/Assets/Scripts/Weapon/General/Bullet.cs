using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int penetration = 1;

    private void Start() {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            if(penetration > 0){
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                penetration--;
            }
            if(penetration <= 0){
                Destroy(gameObject);    
            }
        }
    }

    public void setDamage(int x)
    {
        damage = x;
    }
}
