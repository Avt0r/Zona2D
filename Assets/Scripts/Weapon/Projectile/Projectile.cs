using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float lifetime;
    [SerializeField]
    protected float speed;

    protected Projectile(){}

    protected Projectile(Projectile p)
    {
        this.damage = p.damage;
        this.lifetime = p.lifetime;
        this.speed = p.speed;
    }

    public void SetDamage(int x)
    {
        damage = x;
    }

    public void Rotate(float x, float y, float z)
    {
        transform.Rotate(x,y,z);
    }
}
