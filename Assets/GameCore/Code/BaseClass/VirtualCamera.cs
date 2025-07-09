/* 虚拟相机基类 By ashenguo
   2025/7/8
*/

using System;
using GameCore.Code.Globals;
using GameCore.Code.Player;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    public class  VirtualCamera : MonoBehaviour
    {
        #region UnityBehavior

        protected virtual void Awake()
        {
            _Camera = transform.Find("CameraPivot(UP&Down)/Main Camera").GetComponent<Camera>();
        }

        protected virtual void Start()
        {
            _CameraZPosition = _Camera.transform.localPosition.z;
        }

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }

        #endregion UnityBehavior
        #region PublicMethod

        public void HandleAllCameraActions()
        {
            if (!Follow) return;
            _FollowTarget();
            _HandleRotations();
            _HandleCollisions();
        }
        
        #endregion PublicMethod

        #region PrivateMethod

        private void _FollowTarget()
        {
            var targetCameraPosition = Vector3.SmoothDamp(transform.position, Follow.position,
                ref _CameraVelocity, CameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }

        private void _HandleRotations()
        {
            _LeftAndRightLookAngle += (PlayerController.Instance.CameraHorizontalInput * LeftAndRightRotationSpeed) *
                                      Time.deltaTime;
            _UpAndDownLookAngle -= (PlayerController.Instance.CameraVerticalInput * UpAndDownRotationSpeed) *
                                   Time.deltaTime;
            _UpAndDownLookAngle = Mathf.Clamp(_UpAndDownLookAngle, MinimumPivot, MaximumPivot);

            var cameraRotation = Vector3.zero;
            Quaternion targetRotation;

            cameraRotation.y = _LeftAndRightLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            transform.rotation = targetRotation;

            cameraRotation = Vector3.zero;
            cameraRotation.x = _UpAndDownLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            CameraPivotTransform.localRotation = targetRotation;
        }

        private void _HandleCollisions()
        {
            _TargetCameraZPosition = _CameraZPosition;
            var direction = _Camera.transform.position - CameraPivotTransform.position;
            direction.Normalize();

            if (Physics.SphereCast(CameraPivotTransform.position, CameraCollisionRadius, direction, out var hit,
                    Mathf.Abs(_TargetCameraZPosition), CollideWithLayers))
            {
                var distanceFromHitObject = Vector3.Distance(CameraPivotTransform.position, hit.point);
                _TargetCameraZPosition = -(distanceFromHitObject - CameraCollisionRadius);
            }

            if (Mathf.Abs(_TargetCameraZPosition) < CameraCollisionRadius)
            {
                _TargetCameraZPosition = -CameraCollisionRadius;
            }

            _CameraObjectPosition.z = Mathf.Lerp(_Camera.transform.localPosition.z, _TargetCameraZPosition, 0.2f);
            _Camera.transform.localPosition = _CameraObjectPosition;
        }

        #endregion PrivateMethod
        
        #region Field

        private Camera _Camera;
        private Vector3 _CameraVelocity;
        private Vector3 _CameraObjectPosition;  // 当摄像机发生碰撞时要移动到这个位置
        private float _LeftAndRightLookAngle;
        private float _UpAndDownLookAngle;
        private float _CameraZPosition;
        private float _TargetCameraZPosition;
        
        [Header("Camera Settings")] 
        public Transform Follow;
        public Transform CameraPivotTransform;
        public float CameraSmoothSpeed = 1f; // 值越大，移动摄像机的速度越慢
        public float LeftAndRightRotationSpeed = 20f;
        public float UpAndDownRotationSpeed = 20f;
        public float MinimumPivot = -30f;
        public float MaximumPivot = 60f;
        public LayerMask CollideWithLayers;
        public float CameraCollisionRadius = 0.2f;


        #endregion Field
    }
}