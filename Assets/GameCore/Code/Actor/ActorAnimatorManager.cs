/* 角色动画管理器 By ashenguo
   2025/7/10
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Code.Actor
{
   public sealed class ActorAnimatorManager : MonoBehaviour
   {
      #region UnityBehavior

      private void Awake()
      {
         if (ActorBrain == null)
         {
            ActorBrain = GetComponent<ActorBrainBase>();
         }
      }

      private void Update()
      {
         // 这里对于 horizontalMovement传 0 是因为在非锁定状态下，我们希望角色可以自由移动

         // 非锁定状态
         UpdateAnimatorMovementParameters(0, ActorBrain.Controller.MoveAmount);
         
         // 锁定状态
      }

      #endregion UnityBehavior
    

      public void UpdateAnimatorMovementParameters(float horizontalMovement, float verticalMovement)
      {
         ActorBrain.ActorAnimator.SetFloat(Horizontal, horizontalMovement, 0.1f, Time.deltaTime);
         ActorBrain.ActorAnimator.SetFloat(Vertical, verticalMovement, 0.1f, Time.deltaTime);
      }

      #region Field

      public ActorBrainBase ActorBrain;
      private static readonly int Horizontal = Animator.StringToHash("Horizontal");
      private static readonly int Vertical = Animator.StringToHash("Vertical");

      #endregion Field
   }
}
