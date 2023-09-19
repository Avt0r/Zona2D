using Unity.VisualScripting;
using UnityEngine;

namespace CharacterComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class MovementController : MonoBehaviour
    {
        private CharacterController _controller;
        private States _states;
        private float speedCurrent;
        private Rigidbody2D _rb;
        private Vector2 moveVector;
        private bool onRun;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _states = _controller.states;
            _rb = GetComponent<Rigidbody2D>();
            speedCurrent = _states.Speed;
        }

        private void OnEnable()
        {
            _controller.runButtonPressed += SetRunOn;
            _controller.move += Move;
            _controller.readMove += ReadMove;
        }

        private void OnDisable()
        {
            _controller.runButtonPressed -= SetRunOn;
            _controller.move -= Move;
            _controller.readMove -= ReadMove;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void SetRunOn(bool input)
        {
            onRun = input;
        }

        private void Move()
        {
            if (moveVector == null || _rb == null) return;
            _rb.velocity = moveVector * speedCurrent;
            if (moveVector.magnitude == 0)
            {
                Idle();
            }
            else
            {
                if(onRun)
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
        }
        
        private void Walk()
        {
            speedCurrent = _states.Speed;
            _controller.walk?.Invoke();
        }

        private void Run()
        {
            speedCurrent = _states.Speed + _states.SpeedRun;
            _controller.run?.Invoke();
        }

        private void ReadMove(Vector2 moveVector)
        {
            this.moveVector = moveVector.normalized;
        }

        private void Idle()
        {
            _controller.idle?.Invoke();
        }
    }
}
