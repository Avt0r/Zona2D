using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    void Start()
    {
        particle.Play();
        Destroy(gameObject,2);
    }
}
