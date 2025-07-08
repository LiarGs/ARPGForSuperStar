/* 赋予运动能力需和Controller搭配使用 By ashenguo
   2025/7/4
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Code.Actor
{
    public class LocomotionManager : MonoBehaviour
    {
        #region UnityBehavior
        private void Awake()
        {
            _ActorBrain = GetComponent<ActorBrainBase>();
        }

        private void Start()
        {
            _ActorController = _ActorBrain.ActorController;
            _ActorCamera = _ActorBrain.ActorCamera;
        }

        private void Update()
        {
            // TODO 待引入虚拟摄像机后重构
            if (!_ActorCamera)
            {
                _ActorCamera = _ActorBrain.ActorCamera;
                return;
            }
            _GetControllerInput();
            _HandleAllMovement();
        }
        #endregion UnityBehavior

        private void _GetControllerInput()
        {
            _VerticalMovement = _ActorController.VerticalInput;
            _HorizontalMovement = _ActorController.HorizontalInput;
            _MoveAmount = _ActorController.MoveAmount;
        }

        private void _HandleAllMovement()
        {
            // GroundMovement
            _HandleGroundMovement();
            _HandleRotation();
            // JumpingMovement
            // FallingMovement
        }

        private void _HandleGroundMovement()
        {
            // TODO 对于摄像机的部分可能还需要重构
            _MoveDirection = _ActorCamera.transform.forward * _VerticalMovement;
            _MoveDirection += _ActorCamera.transform.right * _HorizontalMovement;
            _MoveDirection.Normalize();
            _MoveDirection.y = 0;
            Move(_MoveDirection, _MoveAmount);
        }

        private void _HandleRotation()
        {
            _TargetRotationDirection = Vector3.zero;
            _TargetRotationDirection = _ActorCamera.transform.forward * _VerticalMovement;
            _TargetRotationDirection += _ActorCamera.transform.right * _HorizontalMovement;
            _TargetRotationDirection.Normalize();
            _TargetRotationDirection.y = 0;
            
            if (_TargetRotationDirection == Vector3.zero)
            {
                _TargetRotationDirection = transform.forward;
            }

            var newRotation = Quaternion.LookRotation(_TargetRotationDirection);
            var targetRotation = Quaternion.Slerp(transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
        
        public void Move(Vector3 moveDirection, float moveAmount)
        {
            var moveSpeed = moveAmount > 0.5f ? RunningSpeed : WalkingSpeed;
            _ActorBrain.ActorCharacterController.Move(moveDirection * (moveSpeed * Time.deltaTime));
        }
        
        public float WalkingSpeed = 2;
        public float RunningSpeed = 5;
        public float RotationSpeed = 15;

        private ActorBrainBase _ActorBrain;
        private ControllerBase _ActorController;
        private VirtualCamera _ActorCamera;
        private float _VerticalMovement;
        private float _HorizontalMovement;
        private float _MoveAmount;
        private Vector3 _MoveDirection;
        private Vector3 _TargetRotationDirection;
    }
}