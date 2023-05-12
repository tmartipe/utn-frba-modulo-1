using System;
using UnityEngine;

namespace PlayerMovement
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private PlayerLocomotion _playerLocomotion;
        private CameraManager _cameraManager;
        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _playerLocomotion = GetComponent<PlayerLocomotion>();
            _cameraManager = FindObjectOfType<CameraManager>();
        }
        
        private void FixedUpdate()
        {
            _playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate()
        {
            HandleCamera();
        }


        private void HandleCamera()
        {
            _cameraManager.FollowTarget(transform);
            _cameraManager.RotateCamera();
            _cameraManager.HandleCameraCollisions();
        }
    }
}