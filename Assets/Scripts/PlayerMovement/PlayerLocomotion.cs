using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public float movementSpeed = 7f;
    public float rotationSpeed = 15f;

    private InputManager _inputManager;

    private Vector3 _moveDirection;
    private Transform _cameraObject;
    private Rigidbody _rb;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody>();
        _cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        _moveDirection = new Vector3(_cameraObject.forward.x, 0f, _cameraObject.forward.z) * _inputManager.VerticalInput;
        _moveDirection = _moveDirection + _cameraObject.right * _inputManager.HorizontalInput;
        _moveDirection.Normalize();
        _moveDirection.y = 0;

        _rb.velocity = _moveDirection * movementSpeed;
    }

    void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = _cameraObject.forward * _inputManager.VerticalInput;
        targetDirection = targetDirection + _cameraObject.right * _inputManager.HorizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
}