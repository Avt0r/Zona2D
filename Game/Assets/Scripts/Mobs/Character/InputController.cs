using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Character.IControllable))]
public class InputController : MonoBehaviour
{
    private GameInput _gameInput;
    private Character.IControllable _controllable;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _controllable = GetComponent<Character.IControllable>();
    }

    private void OnEnable()
    {
        _gameInput.Gameplay.Run.performed += OnRunPerformed;
        _gameInput.Gameplay.Run.canceled += OnRunCanceled;
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Run.performed -= OnRunPerformed; 
        _gameInput.Gameplay.Run.canceled -= OnRunCanceled; 
    }

    private void Update()
    {
        ReadMovement();
    }

    private void OnRunPerformed(InputAction.CallbackContext obj)
    {
        _controllable.Run();
    }

    private void OnRunCanceled(InputAction.CallbackContext obj)
    {
        _controllable.Walk();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

        _controllable.ReadMove(inputDirection);
    }
}
