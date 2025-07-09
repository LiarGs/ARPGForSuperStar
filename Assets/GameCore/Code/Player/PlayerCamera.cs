/* 玩家视角相机 By ashenguo
   2025/7/8
*/

using GameCore.Code.BaseClass;
using GameCore.Code.Log;

namespace GameCore.Code.Player
{
    public class PlayerCamera : VirtualCamera
    {
        public static PlayerCamera Instance;

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

        protected override void Start()
        {
            base.Start();
            DontDestroyOnLoad(gameObject);
        }

        public void OnEnable()
        {
            SuperDebug.Log("PlayerCamera Enable");
        }
    }
}