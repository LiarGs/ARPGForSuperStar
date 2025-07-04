/* 游戏标题页面 By ashenguo
   2025/7/4
*/

using GameCore.Code.BaseClass;
using GameCore.Code.Globals;
using GameCore.Code.Globals.Managers;
using GameCore.Code.Log;

namespace GameCore.Code.UIControllers
{
    public class GameStartPage : UIControllerBase
    {
        public void OnGameStartBtnPressed()
        {
            _EntryMenu();
        }

        public void OnNewGameBtnPressed()
        {
            _StartGame();
        }

        private void _StartGame()
        {
            StartCoroutine(WorldSaveGameManager.Instance.LoadNewGame());
            SuperDebug.Log("Game Started");
            GlobalVars.GUIManager.ClearAll();
        }

        private void _EntryMenu()
        {
            SuperDebug.Log("Entry Menu");
        }
    }
}