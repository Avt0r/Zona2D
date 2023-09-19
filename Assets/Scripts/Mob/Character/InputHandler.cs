using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterComponents
{
    [RequireComponent(typeof(EventController))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private GameInput _gameInput;
        [SerializeField, HideInInspector]
        private EventController _eventController;

        private void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
            _eventController = GetComponent<EventController>();
        }

        private void OnEnable()
        {
            _gameInput.Gameplay.Run.performed += OnRunPerformed;
            _gameInput.Gameplay.Run.canceled += OnRunCanceled;
            _gameInput.Gameplay.Inventory.performed += OnInventoryPerformed;
            _gameInput.Gameplay.Fire.performed += OnFireAttackPerformed;
        }

        private void OnDisable()
        {
            _gameInput.Gameplay.Run.performed -= OnRunPerformed;
            _gameInput.Gameplay.Run.canceled -= OnRunCanceled;
            _gameInput.Gameplay.Inventory.performed -= OnInventoryPerformed;
            _gameInput.Gameplay.Fire.performed -= OnFireAttackPerformed;
        }

        private void Update()
        {
            ReadMovement();
            ReadGazeDirection();
        }

        private void OnRunPerformed(InputAction.CallbackContext obj)
        {
            _eventController.RunButtonPerformed();
        }

        private void OnRunCanceled(InputAction.CallbackContext obj)
        {
            _eventController.RunButtonCanceled();
        }

        private void OnInventoryPerformed(InputAction.CallbackContext obj)
        {
            _eventController.OpenCloseInventory();
        }

        private void OnFireAttackPerformed(InputAction.CallbackContext obj)
        {
            _eventController.Fire();
        }

        private void ReadMovement()
        {
            Vector2 inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

            _eventController.ReadMove(inputDirection);
        }

        private void ReadGazeDirection()
        {
            Vector2 input = _gameInput.Gameplay.GazeDirection.ReadValue<Vector2>();
            Vector2 result = Camera.main.ScreenToWorldPoint(input) - gameObject.transform.position;
            _eventController.ReadGazeDirection(result);
        }
    }
}
