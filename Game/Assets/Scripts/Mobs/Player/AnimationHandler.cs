using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
[RequireComponent(typeof(Animator))]
internal class AnimationHandler : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void OnEnable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.idle += Idle;
        c.walk += Walk;
        c.run += Walk;
        c.die += Death;
    }

    private void OnDisable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.idle -= Idle;
        c.walk -= Walk;
        c.run -= Walk;
        c.die -= Death;
    }
    
    private void Idle()
    {
        anim.Play("Idle");
    }

    private void Walk()
    {
        anim.Play("Walk");
    }

    private void Death()
    {
        Player.Controller c = GetComponent<Player.Controller>();
        c.idle -= Idle;
        c.walk -= Walk;
        c.run -= Walk;
        anim.Play("Death");
    }
}
}
