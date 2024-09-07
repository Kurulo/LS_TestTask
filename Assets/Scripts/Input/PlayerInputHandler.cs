using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler
{
    private PlayerInput _inputActions;
    public PlayerInput InputActions { get { return _inputActions; } }

    public PlayerInputHandler() {
        _inputActions = new PlayerInput();
        _inputActions.Enable();
    }

    public Vector2 GetKeyboardInput() {
        return _inputActions.MobileMovementInput.Movement.ReadValue<Vector2>();
    }
}
