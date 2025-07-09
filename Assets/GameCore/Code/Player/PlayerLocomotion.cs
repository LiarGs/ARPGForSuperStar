/* 赋予玩家操控的功能，需和 PlayerCharacterController 搭配使用 By ashenguo
   2025/7/4
*/

using GameCore.Code.Globals;
using GameCore.Code.Log;
using UnityEngine;

namespace GameCore.Code.Player
{
    public class PlayerLocomotion : MonoBehaviour
    {
        #region UnityBehavior
        private void Awake()
        {
            if (PlayerController.Instance == null)
            {
                PlayerCharacterController = GetComponent<CharacterController>();
            }
        }
        
        private void Update()
        {
            _GetControllerInput();
            _HandleAllMovement();
        }
        #endregion UnityBehavior

        private void _GetControllerInput()
        {
            _MoveAmount = GlobalVars.GPlayerController.MoveAmount;
            _VerticalInput = GlobalVars.GPlayerController.VerticalInput;
            _HorizontalInput = GlobalVars.GPlayerController.HorizontalInput;
        }

        private void _HandleAllMovement()
        {
            _HandleGroundMovement();
            _HandleRotation();
            // JumpingMovement
            // FallingMovement
        }

        private void _HandleGroundMovement()
        {
            _HandleMoveDirection();
            Move(_MoveDirection, _MoveAmount);
        }

        private void _HandleMoveDirection()
        {
            _MoveDirection = GlobalVars.GPlayerCamera.transform.forward * _VerticalInput;
            _MoveDirection += GlobalVars.GPlayerCamera.transform.right * _HorizontalInput;
            _MoveDirection.Normalize();
            _MoveDirection.y = 0;
        }

        public void Move(Vector3 moveDirection, float moveAmount)
        {
            var moveSpeed = moveAmount > 0.5f ? RunningSpeed : WalkingSpeed;
            PlayerCharacterController.Move(moveDirection * (moveSpeed * Time.deltaTime));
        }

        private void _HandleRotation()
        {
            _TargetRotationDirection = Vector3.zero;
            _TargetRotationDirection = GlobalVars.GPlayerCamera.transform.forward * _VerticalInput;
            _TargetRotationDirection += GlobalVars.GPlayerCamera.transform.right * _HorizontalInput;
            _TargetRotationDirection.Normalize();
            _TargetRotationDirection.y = 0;

            _Rotation(_TargetRotationDirection);
        }
        
        private void _Rotation(Vector3 rotationDirection)
        {
            if (rotationDirection == Vector3.zero)
            {
                rotationDirection = transform.forward;
            }

            var newRotation = Quaternion.LookRotation(rotationDirection);
            var targetRotation = Quaternion.Slerp(transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
        
        public CharacterController PlayerCharacterController;
        public float WalkingSpeed = 2;
        public float RunningSpeed = 5;
        public float RotationSpeed = 15;
        
        private float _VerticalInput;
        private float _HorizontalInput;
        private float _MoveAmount;
        private Vector3 _MoveDirection;
        private Vector3 _TargetRotationDirection;
    }
}