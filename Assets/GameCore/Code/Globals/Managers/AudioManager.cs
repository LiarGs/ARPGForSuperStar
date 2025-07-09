/* 音乐管理器 By ashenguo
   2025/7/4
*/

using GameCore.Code.Log;

namespace GameCore.Code.Globals.Managers
{
    public class AudioManager
    {
        private static AudioManager _Instance;

        private AudioManager()
        {
        }

        public static AudioManager Instance
        {
            get { return _Instance ??= new AudioManager(); }
        }
        
        public void OnEnable()
        {
            SuperDebug.Log("AudioManager Enable");
        }

        public void OnDisable()
        {
            SuperDebug.Log("AudioManager Disable");
        }
    }
}