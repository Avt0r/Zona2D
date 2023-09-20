using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Moving : MonoBehaviour
    {
        [SerializeField]
        private float distance;
        [SerializeField]
        private int speed;
        [SerializeField, HideInInspector]
        private Vector2 move;
        [SerializeField, HideInInspector]
        private Rigidbody2D rb;
        [SerializeField, HideInInspector]
        private Transform owner;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            owner = null;
            StartCoroutine(TryToCatchPlayer());
        }

        private void FixedUpdate()
        {
            Follow();
        }

        private IEnumerator TryToCatchPlayer()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                try
                {
                    break;
                }
                catch (NullReferenceException){}
            }
        }

        private void Follow()
        {
            if (owner == null) { return; }
            move.x = owner.position.x - this.transform.position.x;
            move.y = owner.position.y - this.transform.position.y;

            rb.velocity = move.normalized * (move.magnitude > distance ? speed * (move.magnitude - distance) : 0);
        }
    }
}