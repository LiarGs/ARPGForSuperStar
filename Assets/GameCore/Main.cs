/* 游戏主循环 By ashenguo
   2025/7/4
*/

using GameCore.Code.Globals;
using UnityEngine;

namespace GameCore
{
    public class Main : MonoBehaviour
    {
        public static Main Instance;
        #region UnityBehavior

        private void Awake()
        {
            //这样写单例确保进入新场景时被新场景的 Main 接管
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
        }

        private void OnEnable()
        {
            GlobalVars.OnEnable();
        }
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (CurrentGameScene == GameScene.MainMenu)
            {
                GlobalVars.GUIManager.LoadPage("Prefabs/UI/GameStartPage");
            }
        }

        private void OnDisable()
        {
            GlobalVars.OnDisable();
        }

        #endregion UnityBehavior
        
        public GameScene CurrentGameScene;
    }

    public enum GameScene
    {
        MainMenu,
        WorldScene
    }
}