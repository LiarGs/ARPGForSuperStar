/* Character 大脑基类 By ashenguo
   2025/7/4
*/

using System;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    public abstract class ActorBrainBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            ActorCharacterController = GetComponent<CharacterController>();
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }
        
        // 这些组件由具体的Brain在Awake中去获取
        public CharacterController ActorCharacterController;
        public ControllerBase ActorController;
        [NonSerialized]
        public VirtualCamera ActorCamera;
    }
}