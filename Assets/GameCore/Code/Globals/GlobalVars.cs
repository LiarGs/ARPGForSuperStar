/* 游戏全局变量 By ashenguo
   2025/7/4
*/

using GameCore.Code.Globals.Managers;
using GameCore.Code.Player;

namespace GameCore.Code.Globals
{
    public static class GlobalVars
    {
        #region UnityBehavoir

        public static void OnEnable()
        {
            GSoundManager.OnEnable();
            GAudioManager.OnEnable();
        }

        public static void OnDisable()
        {
            GSoundManager.OnDisable();
            GAudioManager.OnDisable();
        }
        #endregion UnityBehavoir
        
        public static MainPlayer GPlayer => MainPlayer.Instance;
        public static PlayerCamera GPlayerCamera => PlayerCamera.Instance;
        public static PlayerController GPlayerController => PlayerController.Instance;
        public static WorldSaveGameManager GWorldSaveGameManager => WorldSaveGameManager.Instance;
        public static GameStateManager GGameStateManager => GameStateManager.Instance;
        public static UIManager GUIManager => UIManager.Instance;
        public static SoundManager GSoundManager => SoundManager.Instance;
        public static AudioManager GAudioManager => AudioManager.Instance;
        public static EventManager GEventManager => EventManager.Instance;
    }
}