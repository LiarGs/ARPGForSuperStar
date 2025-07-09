/* 管理Actor身上所有的技能 By ashenguo
   2025/7/8
*/

using System.Collections.Generic;
using GameCore.Code.BaseClass;
using UnityEngine;
namespace GameCore.Ability
{
    public class AbilityManager : MonoBehaviour
    { 
        #region UnityBehavior

        #endregion UnityBehavior
        
        public void Execute(int abilityNumber, GameObject target)
        {
            var ability = Abilities[abilityNumber];
            if (!ability.IsActive) return;
            foreach (var abilityEffect in ability.Effects)
            {
                abilityEffect.Execute(gameObject, target);
            }
        }

        public void ActiveAbility(int abilityNumber)
        {
            var ability = Abilities[abilityNumber];
            ability.IsActive = true;
        }

        public void DeActiveAbility(int abilityNumber)
        {
            var ability = Abilities[abilityNumber];
            ability.IsActive = false;
        }
        
        [SerializeField]
        public List<AbilityConfigBase> Abilities;
    }
}