/* 音效管理器 By ashenguo
   2025/7/4
*/

using GameCore.Code.Log;

namespace GameCore.Code.Globals.Managers
{
    public class SoundManager
    {
        private static SoundManager _Instance;
        
        private SoundManager()
        {
        }

        public static SoundManager Instance
        {
            get { return _Instance ??= new SoundManager(); }
        }

        public void OnEnable()
        {
            SuperDebug.Log("SoundManager Enable");
        }

        public void OnDisable()
        {
            SuperDebug.Log("SoundManager Disable");
        }
    }
}