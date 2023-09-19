using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : Projectile
{
    
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int penetration;

    public Bullet(){
    }

    public Bullet(int damage, int penetration)
    {
        this.damage = damage;
        lifetime = 3;
        speed = 50;
        this.penetration = penetration;
    }

    public Bullet(Bullet bullet) {
        this.damage = bullet.damage;
        this.penetration = bullet.penetration;
        this.lifetime = bullet.lifetime;
        this.speed = bullet.speed;
    }

    private void Start() {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) return;
        if(other.gameObject.CompareTag("Enemy"))
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
}
