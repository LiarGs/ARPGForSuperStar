/* 主动技能配置 By ashenguo
   2025/7/9
*/


using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Ability
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "ScriptableObjects/ActiveAbilityConfig")]
    public class ActiveAbilityConfig : AbilityConfigBase
    {
        public float AbilityCD = 0f;
    }
}