/* 玩家大脑 By ashenguo
   2025/7/4
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Code.Player
{
    public class PlayerBrain : ActorBrainBase
    {
        protected override void Awake()
        {
            base.Awake();
            ActorController = GetComponent<PlayerController>();
            ActorCamera = PlayerCamera.Instacne;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            // TODO 待引入虚拟摄像机后重构
            if (!ActorCamera)
            {
                ActorCamera = PlayerCamera.Instacne;
            }
        }
    }
}