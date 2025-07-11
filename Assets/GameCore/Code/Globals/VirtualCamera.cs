/* 虚拟相机基类 By ashenguo
   2025/7/8
*/

using UnityEngine;

namespace GameCore.Code.Globals
{
    public class VirtualCamera : MonoBehaviour
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

        protected virtual void LateUpdate()
        {
            _HandleAllCameraActions();
        }

        protected virtual void OnDisable()
        {
            
        }

        #endregion UnityBehavior
        #region PublicMethod

        private void _HandleAllCameraActions()
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
            _LeftAndRightLookAngle += (GlobalVars.GPlayerController.CameraHorizontalInput * LeftAndRightRotationSpeed) *
                                      Time.deltaTime;
            _UpAndDownLookAngle -= (GlobalVars.GPlayerController.CameraVerticalInput * UpAndDownRotationSpeed) *
                                   Time.deltaTime;
            _UpAndDownLookAngle = Mathf.Clamp(_UpAndDownLookAngle, MinimumPivot, MaximumPivot);

            var cameraRotation = Vector3.zero;

            cameraRotation.y = _LeftAndRightLookAngle;
            var targetRotation = Quaternion.Euler(cameraRotation);
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

        protected float LeftAndRightRotationSpeed;
        protected float UpAndDownRotationSpeed;
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
        public float MouseLeftAndRightRotationSpeed = 20f;
        public float MouseUpAndDownRotationSpeed = 20f;
        public float GamepadLeftAndRightRotationSpeed = 220f;
        public float GamepadUpAndDownRotationSpeed = 220f;
        public float MinimumPivot = -30f;
        public float MaximumPivot = 60f;
        public LayerMask CollideWithLayers;
        public float CameraCollisionRadius = 0.2f;

        #endregion Field
    }
}