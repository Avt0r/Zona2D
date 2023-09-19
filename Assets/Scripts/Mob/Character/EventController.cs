using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComponents
{
    internal class EventController : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void ReadGazeDirection(Vector2 input)
        {
            _controller.readGazeDirection?.Invoke(input);
        }

        public void Fire()
        {
            _controller.fire?.Invoke();
        }

        public void Idle()
        {
            _controller.idle?.Invoke();  
        }

        public void Move()
        {
            _controller.move?.Invoke();
        }

        public void OpenCloseInventory()
        {
            _controller.openCloseInventory?.Invoke();
        }

        public void ReadMove(Vector2 moveVector)
        {
            _controller.readMove?.Invoke(moveVector);
        }

        public void RunButtonPerformed()
        {
            _controller.runButtonPressed?.Invoke(true);
        }

        public void RunButtonCanceled()
        {
            _controller.runButtonPressed?.Invoke(false);
        }
    }
}