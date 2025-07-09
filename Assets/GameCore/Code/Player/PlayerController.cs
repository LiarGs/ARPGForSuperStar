/* 玩家角色控制器 接收并处理玩家输入 如移动，释放技能等 By ashenguo
   2025/7/8
*/

using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore.Code.Player
{
    public class PlayerController
    {
        private static PlayerController _Instance;

        private PlayerController()
        {
        }

        public static PlayerController Instance
        {
            get { return _Instance ??= new PlayerController(); }
        }

        public void OnEnable()
        {
            _InputController ??= new InputControl();
            _InputController.Enable();
            _InputController.GamePlay.Move.performed += i => _MovementInput = i.ReadValue<Vector2>();
            _InputController.GamePlay.Look.performed += i => _CameraInput = i.ReadValue<Vector2>();
        }

        public void Update()
        {
            _HandleMovementInput();
            _HandleCameraInput();
        }

        public void OnDisable()
        {
            _InputController.Disable();
        }
        
        private void _HandleMovementInput()
        {
            VerticalInput = _MovementInput.y;
            HorizontalInput = _MovementInput.x;
            MoveAmount = Mathf.Clamp01(Mathf.Abs(VerticalInput) + Mathf.Abs(HorizontalInput));
            switch (MoveAmount)
            {
                case > 0 and <= 0.5f:
                    MoveAmount = 0.5f;
                    break;
                case > 0.5f and < 1:
                    MoveAmount = 1f;
                    break;
            }
        }

        private void _HandleCameraInput()
        {
            CameraVerticalInput = _CameraInput.y;
            CameraHorizontalInput = _CameraInput.x;
        }

        #region Field

        // 玩家控制器对外暴露属性
        public InputDevice ControllerDevice => _InputController.GamePlay.Move.activeControl.device;
        public float VerticalInput;
        public float HorizontalInput;
        public float MoveAmount;

        public float CameraVerticalInput;
        public float CameraHorizontalInput;

        private Vector2 _MovementInput;
        private Vector2 _CameraInput;
        private InputControl _InputController;

        #endregion Field

    }
}