/* 游戏世界加载管理器 By ashenguo
   2025/7/4
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore.Code.Globals.Managers
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager Instance;

        [SerializeField] public int WorldSceneIndex = 1;

        public IEnumerator LoadNewGame()
        {
            var loadOperation = SceneManager.LoadSceneAsync(WorldSceneIndex);
            yield return null;
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
    }
}