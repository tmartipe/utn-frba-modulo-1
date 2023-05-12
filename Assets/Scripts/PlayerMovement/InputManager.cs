using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;
    public float VerticalInput => _movementInput.y;
    public float HorizontalInput => _movementInput.x;

    public float CameraVerticalInput => _cameraInput.y;
    public float CameraHorizontalInput => _cameraInput.x;

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
        }
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

}
