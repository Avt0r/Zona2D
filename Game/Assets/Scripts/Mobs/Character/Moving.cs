using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class Moving : MonoBehaviour, IControllable
    {
        [SerializeField, HideInInspector]
        private Controller controller;
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
        [SerializeField, HideInInspector]
        private bool onRun;
        private void Awake()
        {
            controller = GetComponent<Controller>();
        }

        private void Start()
        {
            ((IControllable)this).Walk();
        }

        private void FixedUpdate()
        {
            ((IControllable)this).Move();
        }

        void IControllable.Walk()
        {
            onRun = false;
            speedCurrent = speed;
        }

        void IControllable.Move()
        {
            rb.velocity = moveVector * speedCurrent;
            if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                ((IControllable)this).Idle();
            }
            else
            {
                if (onRun)
                {
                    controller.run?.Invoke();
                }
                else
                {
                    controller.walk?.Invoke();
                }
            }
        }

        void IControllable.Run()
        {
            onRun = true;
            speedCurrent = speed + speedRun;
        }

        void IControllable.ReadMove(Vector2 moveVector)
        {
            this.moveVector = moveVector.normalized;
        }

        void IControllable.Idle()
        {
            controller.idle?.Invoke();
        }
    }
}
