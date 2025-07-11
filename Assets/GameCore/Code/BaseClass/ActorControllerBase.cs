/* Actor控制器 By ashenguo
   2025/7/4
*/

using UnityEngine;

namespace GameCore.Code.BaseClass
{
   public abstract class ActorControllerBase : MonoBehaviour
   {
      #region Field

      public abstract Vector3 Forward { get; }
      public abstract Vector3 Right { get; }
      public abstract float MoveAmount { get; }
      public abstract float VerticalInput { get; }
      public abstract float HorizontalInput { get; }
      
      #endregion Field

   }
}