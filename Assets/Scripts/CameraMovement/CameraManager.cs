using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    private InputManager _inputManager;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private float _defaultPosition;
    
    public float followSpeed = 0.2f;
    public float cameraLookSpeed = 2f;
    public float cameraPivotSpeed = 2f;

    public float minimumPivotAngle = -35f;
    public float maximumPivotAngle = 35f;

    public float lookAngle; 
    public float pivotAngle;

    public Transform cameraPivot;
    public Transform cameraTransform;
    public float collisionRadius = .2f;
    public float collisionOffset = .2f;
    public float minimumCollisionOffset = .2f;
    public LayerMask collisionLayers;
    private Vector3 cameraVectorPosition;

private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        cameraTransform = Camera.main.transform;
        _defaultPosition = cameraTransform.localPosition.z;
    }
    
    
    public void FollowTarget(Transform targetTransform)
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, followSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera()
    {
        lookAngle = lookAngle + (_inputManager.CameraHorizontalInput * cameraLookSpeed);
        pivotAngle = pivotAngle - (_inputManager.CameraVerticalInput * cameraPivotSpeed);

        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);
        
        Vector3 rotation = new Vector3(0, lookAngle, 0);
        transform.rotation = Quaternion.Euler(rotation);

        rotation = new Vector3(pivotAngle, 0, 0);
        cameraPivot.localRotation = Quaternion.Euler(rotation);
    }

    public void HandleCameraCollisions()
    {
        float targetPosition = _defaultPosition;
        RaycastHit hit;
        Vector3 direction = (cameraTransform.position - cameraPivot.position).normalized;

        bool cameraCollided = Physics.SphereCast(cameraPivot.transform.position, collisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers);
        if (cameraCollided)
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = -(distance - collisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
            targetPosition -= minimumCollisionOffset;

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
