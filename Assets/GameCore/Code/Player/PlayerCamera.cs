/* 玩家视角相机 By ashenguo
   2025/7/8
*/

using GameCore.Code.BaseClass;

namespace GameCore.Code.Player
{
    public class PlayerCamera : VirtualCamera
    {
        public static PlayerCamera Instacne;

        private void Awake()
        {
            if (Instacne == null)
            {
                Instacne = this;
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