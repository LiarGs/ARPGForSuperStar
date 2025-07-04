/* 游戏主循环 By ashenguo
   2025/7/4
*/

using System.Collections;
using GameCore.Code.Globals;
using UnityEngine;

namespace GameCore
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(_InitAfterStart());
        }

        private IEnumerator _InitAfterStart()
        {
            yield return null; // 等待一帧
            GlobalVars.Init();
        }
    }
}