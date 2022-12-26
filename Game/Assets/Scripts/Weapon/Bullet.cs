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
    private float distance;
    [SerializeField]
    private int damage;
    [SerializeField]
    private LayerMask whatIsSolid;
    [SerializeField]
    private Rigidbody2D rb;

    private void Start() {
        rb.AddForce(transform.up * speed * 0.1f);
    }

    private void Update()
    {        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if(lifetime > 0)
        {
            lifetime --;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void setDamage(int x)
    {
        damage = x;
    }
}
