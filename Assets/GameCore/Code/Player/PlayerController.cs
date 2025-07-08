/* 玩家角色控制器 接收并处理玩家输入 By ashenguo
   2025/7/8
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Code.Player
{
    public class PlayerController : ControllerBase
    {
        #region UnityBehavior

        protected override void OnEnable()
        {
            base.OnEnable();
            InputController.GamePlay.Move.performed += i => _InputDirection = i.ReadValue<Vector2>();
        }

        private void Update()
        {
            _HandleMovementInput();
        }
        #endregion UnityBehavior
        
        private void _HandleMovementInput()
        {
            VerticalInput = _InputDirection.y;
            HorizontalInput = _InputDirection.x;
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
        
        private Vector2 _InputDirection; 
    }
}