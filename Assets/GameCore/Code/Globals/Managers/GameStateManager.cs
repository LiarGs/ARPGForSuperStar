/* 管理游戏状态 By ashenguo
   2025/7/9
*/


namespace GameCore.Code.Globals.Managers
{
    public class GameStateManager
    {
        private static GameStateManager _Instance;

        private GameStateManager()
        {
        }

        public static GameStateManager Instance
        {
            get { return _Instance ??= new GameStateManager(); }
        }

        public GameState CurrentGameState { get; set; }
    }

    public enum GameState
    {
    }

}