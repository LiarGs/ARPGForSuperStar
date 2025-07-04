/* Unity日志系统 By ashenguo
   2025/7/4
*/

using UnityEngine;

namespace GameCore.Code.Log
{
    public class UnityDebug : ILogSystem
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }
    }
}