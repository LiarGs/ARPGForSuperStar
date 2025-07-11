/* 赋予 Actor 运动能力, 由 Controller 控制 By ashenguo
   2025/7/10
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Code.Actor
{
    public class ActorLocomotion : MonoBehaviour
    {
        #region UnityBehavior

        protected virtual void Awake()
        {
            if (ActorBrain == null)
            {
                ActorBrain = GetComponent<ActorBrainBase>();
            }
        }

        protected virtual void Update()
        {
            _GetControllerInput();
            _HandleAllMovement();
        }

        #endregion UnityBehavior

        private void _GetControllerInput()
        {
            _VerticalInput = ActorBrain.Controller.VerticalInput;
            _HorizontalInput = ActorBrain.Controller.HorizontalInput;
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
            _MoveDirection = ActorBrain.Controller.Forward * _VerticalInput;
            _MoveDirection += ActorBrain.Controller.Right * _HorizontalInput;
            _MoveDirection.Normalize();
            _MoveDirection.y = 0;

            _Move(_MoveDirection, ActorBrain.Controller.MoveAmount);
        }

        private void _Move(Vector3 moveDirection, float moveAmount)
        {
            var moveSpeed = moveAmount > 0.5f ? RunningSpeed : WalkingSpeed;
            ActorBrain.ActorCharacterController.Move(moveDirection * (moveSpeed * Time.deltaTime));
        }

        private void _HandleRotation()
        {
            _TargetRotationDirection = ActorBrain.Controller.Forward * _VerticalInput;
            _TargetRotationDirection += ActorBrain.Controller.Right * _HorizontalInput;
            _TargetRotationDirection.Normalize();
            _TargetRotationDirection.y = 0;

            _Rotation(_TargetRotationDirection);
        }

        private void _Rotation(Vector3 rotationDirection)
        {
            if (rotationDirection == Vector3.zero)
            {
                rotationDirection = ActorBrain.transform.forward;
            }

            var newRotation = Quaternion.LookRotation(rotationDirection);
            var targetRotation =
                Quaternion.Slerp(ActorBrain.transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
            ActorBrain.transform.rotation = targetRotation;
        }

        #region Field

        public ActorBrainBase ActorBrain;

        public float WalkingSpeed = 2;
        public float RunningSpeed = 5;
        public float RotationSpeed = 15;

        private float _VerticalInput;
        private float _HorizontalInput;
        private Vector3 _MoveDirection;
        private Vector3 _TargetRotationDirection;

        #endregion Field
    }
}