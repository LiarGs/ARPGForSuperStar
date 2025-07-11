/* 玩家视角相机 By ashenguo
   2025/7/8
*/

using GameCore.Code.Globals;
using GameCore.Code.Log;
using UnityEngine;
using UnityEngine.InputSystem;
using EventType = GameCore.Code.Globals.EventType;

namespace GameCore.Code.Player
{
    public class PlayerCamera : VirtualCamera
    {
        public static PlayerCamera Instance;

        #region UnityBehavior

        protected override void Awake()
        {
            base.Awake();
            //这样写单例确保进入新场景时被新场景的 PlayerCamera 接管
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            GlobalVars.GEventManager.AddEventListener<InputDevice>(EventType.InputDeviceChange,
                _OnDeviceChanged);
            GlobalVars.GEventManager.AddEventListener<GameObject>(EventType.MainPlayerChange,
                player => Follow = player.transform);
            SuperDebug.Log("PlayerCamera Enable");
        }
        
        protected override void Start()
        {
            base.Start();
            DontDestroyOnLoad(gameObject);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GlobalVars.GEventManager.RemoveEventListener<InputDevice>(EventType.InputDeviceChange,
                _OnDeviceChanged);
            SuperDebug.Log("PlayerCamera Disable");
        }

        #endregion UnityBehavior

        private void _OnDeviceChanged(InputDevice inputDevice)
        {
            switch (inputDevice)
            {
                case Gamepad:
                    // SuperDebug.Log("Gamepad Control");
                    LeftAndRightRotationSpeed = GamepadLeftAndRightRotationSpeed;
                    UpAndDownRotationSpeed = GamepadUpAndDownRotationSpeed;
                    break;
                case Mouse:
                    // SuperDebug.Log("Mouse Control");
                    LeftAndRightRotationSpeed = MouseLeftAndRightRotationSpeed;
                    UpAndDownRotationSpeed = MouseUpAndDownRotationSpeed;
                    break;
                case Keyboard:
                    // SuperDebug.Log("Keyboard Control");
                    break;
            }
        }
    }
}