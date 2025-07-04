/* 日志系统接口 By ashenguo
   2025/7/4
*/

namespace GameCore.Code.Log
{
    public interface ILogSystem
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}