/* 游戏全局变量 By ashenguo
   2025/7/4
*/

using GameCore.Code.Globals.Managers;

namespace GameCore.Code.Globals
{
    public class GlobalVars
    {
        public static void Init()
        {
            GUIManager.Init();
            GSoundManager.Init();
            GAudioManager.Init();
        }

        public static readonly UIManager GUIManager = UIManager.Instance;
        public static readonly SoundManager GSoundManager = SoundManager.Instance;
        public static readonly AudioManager GAudioManager = AudioManager.Instance;
    }
}