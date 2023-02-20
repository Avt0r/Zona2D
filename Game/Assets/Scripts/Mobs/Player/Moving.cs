using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
[RequireComponent(typeof(Rigidbody2D))]
internal class Moving : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private float speedRun;
    [SerializeField, HideInInspector]
    private float speedCurrent;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField, HideInInspector]
    private Vector2 moveVector;

    private void Start()
    {
        Walk();
    }

    private void OnEnable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.move += Move;
        c.run += Run;
        c.walk += Walk;
    }

    private void OnDisable() {
        Player.Controller c = GetComponent<Player.Controller>();
        c.move -= Move;
        c.run -= Run;
        c.walk -= Walk;
    }

    private void Move(Vector2 moveVector)
    {
        rb.velocity = moveVector * speedCurrent;
    }

    private void Run()
    {
        speedCurrent = speed + speedRun;
    }

    private void Walk()
    {
         speedCurrent = speed;
    }
}
}
