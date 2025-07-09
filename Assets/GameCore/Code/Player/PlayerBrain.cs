/* 玩家大脑 By ashenguo
   2025/7/4
*/

using GameCore.Code.BaseClass;
using GameCore.Code.Globals;

namespace GameCore.Code.Player
{
    public class PlayerBrain : ActorBrainBase
    {
        #region UnityBehavior

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            GlobalVars.GPlayerCamera.HandleAllCameraActions();
        }

        #endregion UnityBehavior 
    }
}