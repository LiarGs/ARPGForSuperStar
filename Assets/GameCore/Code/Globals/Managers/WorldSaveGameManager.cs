/* 游戏世界加载管理器 By ashenguo
   2025/7/4
*/

using System.Collections;
using UnityEngine.SceneManagement;

namespace GameCore.Code.Globals.Managers
{
    public class WorldSaveGameManager
    {
        private static WorldSaveGameManager _Instance;

        private WorldSaveGameManager()
        {
        }

        public static WorldSaveGameManager Instance
        {
            get { return _Instance ??= new WorldSaveGameManager(); }
        }

        public static IEnumerator LoadNewGame()
        {
            var loadOperation = SceneManager.LoadSceneAsync(WorldSceneIndex);
            yield return loadOperation;
        }
        
        private const int WorldSceneIndex = 1;
    }
}