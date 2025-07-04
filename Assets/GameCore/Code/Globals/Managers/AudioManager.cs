/* 音乐管理器 By ashenguo
   2025/7/4
*/

using GameCore.Code.Log;
using UnityEngine;

namespace GameCore.Code.Globals.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public void Init()
        {
            SuperDebug.Log("AudioManager Init");
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}