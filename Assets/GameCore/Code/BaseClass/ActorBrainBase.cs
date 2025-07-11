/* Actor 大脑基类 By ashenguo
   2025/7/4
*/

using GameCore.Code.Log;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    public abstract class ActorBrainBase : MonoBehaviour
    {
        #region UnityBehavior

        protected virtual void Awake()
        {
            ActorCharacterController ??= GetComponent<CharacterController>();

            ActorAnimator ??= GetComponent<Animator>();
            
            Controller ??= GetComponent<ActorControllerBase>();
            
            if (Controller == null)
            {
                SuperDebug.LogError($"Actor {name} is missing a Controller component");
            }
        }

        #endregion UnityBehavior
        
        #region Field
        
        [Tooltip("决定是受玩家控制还是AI控制")]
        public ActorControllerBase Controller;
        [HideInInspector] public CharacterController ActorCharacterController;
        [HideInInspector] public Animator ActorAnimator;
        
        #endregion Field
    }
}