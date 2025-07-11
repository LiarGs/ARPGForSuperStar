/* 玩家角色控制器 只接收并简单处理玩家输入 如移动，释放技能等 不能由它去进一步处理输入带来的逻辑 By ashenguo
   2025/7/8
*/

using GameCore.Code.BaseClass;
using GameCore.Code.Globals;
using UnityEngine;
using UnityEngine.InputSystem;
using EventType = GameCore.Code.Globals.EventType;

namespace GameCore.Code.Player
{
    public class PlayerController : ActorControllerBase
    { 
        #region UnityBehavior

        public static PlayerController Instance;
        private void Awake()
        {
            //这样写单例确保进入新场景时被新场景的 PlayerController 接管
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
            _InputController = new InputControl();
        }

        public void OnEnable()
        {
            _InputController.Enable();
            _InputController.GamePlay.Move.performed += _OnMovePerformed;
            _InputController.GamePlay.Look.performed += _OnLookPerformed;
        }

        public void Update()
        {
            _HandleMovementInput();
        }

        public void OnDisable()
        {
            _InputController.GamePlay.Move.performed -= _OnMovePerformed;
            _InputController.GamePlay.Look.performed -= _OnLookPerformed;
            _InputController.Disable();
        }

        #endregion UnityBehavior

        private void _OnMovePerformed(InputAction.CallbackContext context)
        {
            _MovementInput = context.ReadValue<Vector2>();
            if (CurrentControllerDevice == context.control.device) return;

            CurrentControllerDevice = context.control.device;
            GlobalVars.GEventManager.TriggerEvent(EventType.InputDeviceChange, CurrentControllerDevice);
        }

        private void _OnLookPerformed(InputAction.CallbackContext context)
        {
            _CameraInput = context.ReadValue<Vector2>();
            if (CurrentControllerDevice == context.control.device) return;
            
            CurrentControllerDevice = context.control.device;
            GlobalVars.GEventManager.TriggerEvent(EventType.InputDeviceChange, CurrentControllerDevice);
        }
        
        private void _HandleMovementInput()
        {
            _MoveAmount = Mathf.Clamp01(Mathf.Abs(VerticalInput) + Mathf.Abs(HorizontalInput));
            switch (_MoveAmount)
            {
                case > 0 and <= 0.5f:
                    _MoveAmount = 0.5f;
                    break;
                case > 0.5f and < 1:
                    _MoveAmount = 1f;
                    break;
            }
        }

        #region Field
        
        // 玩家控制器对外暴露属性
        public InputDevice CurrentControllerDevice { get; private set; }
        
        // Move Input
        public override Vector3 Forward => GlobalVars.GPlayerCamera.transform.forward;
        public override Vector3 Right => GlobalVars.GPlayerCamera.transform.right;
        public override float MoveAmount => _MoveAmount;
        public override float VerticalInput => _MovementInput.y;
        public override float HorizontalInput => _MovementInput.x;

        // CameraMove Input
        public float CameraVerticalInput => _CameraInput.y;
        public float CameraHorizontalInput => _CameraInput.x;
        
        // Player Action Input
        // private bool DodgeInput = false;
        
        private Vector2 _MovementInput;
        private float _MoveAmount;
        private Vector2 _CameraInput;
        private InputControl _InputController;

        #endregion Field

    }
}