/* 决定玩家操控的角色(GameObject) By ashenguo
   2025/7/11
*/

using GameCore.Code.BaseClass;
using GameCore.Code.Globals;
using GameCore.Code.Log;
using UnityEngine;
using EventType = GameCore.Code.Globals.EventType;

namespace GameCore.Code.Player
{
    public class MainPlayer : MonoBehaviour
    {
        public static MainPlayer Instance;
        #region UnityBehavior

        private void Awake()
        {
            //这样写单例确保进入新场景时被新场景的 PlayerController 接管
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;

            if (_Player == null)
            {
                SuperDebug.LogWarning("没有设置玩家操控角色!!");
            }

            _LastPlayerInspector = _Player;
        }

        #endregion UnityBehavior
        
        #region Field

        public GameObject Player
        {
            get => _Player;
            set
            {
                if (_Player == value) return;
                var oldPlayerBrain = _Player.GetComponent<ActorBrainBase>();
                oldPlayerBrain.Controller = oldPlayerBrain.GetComponent<ActorControllerBase>();
                _Player = value;
                _OnPlayerChange();
            }
        }

        private void _OnPlayerChange()
        {
            var newPlayerBrain = _Player.GetComponent<ActorBrainBase>();
            newPlayerBrain.Controller = GetComponent<PlayerController>();

            _LastPlayerInspector = _Player;
            SuperDebug.Log("主角更换！");
            GlobalVars.GEventManager.TriggerEvent(EventType.MainPlayerChange, _Player);
        }

        [SerializeField] private GameObject _Player;
        private GameObject _LastPlayerInspector;

        #endregion Field

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_LastPlayerInspector != null)
            {
                var oldPlayerBrain = _LastPlayerInspector.GetComponent<ActorBrainBase>();
                oldPlayerBrain.Controller = oldPlayerBrain.GetComponent<ActorControllerBase>();
            }
            _OnPlayerChange();
        }
#endif
    }
}