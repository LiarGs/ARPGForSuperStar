/* 管理Actor身上所有的技能 By ashenguo
   2025/7/8
*/

using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.Ability
{
    public class AbilityManager : MonoBehaviour
    {
        private void Awake()
        {
            foreach (var ability in GetComponents<AbilityBase>())
            {
                Abilities.Add(ability);
            }
        }

        public void ActiveAbility(AbilityBase ability)
        {
            if (Abilities.Contains(ability))
            {
                ability.OnActive();
            }
        }

        public void DeActiveAbility(AbilityBase ability)
        {
            if (Abilities.Contains(ability))
            {
                ability.OnDeActive();
            }
        }
        
        public void ActiveAllAbilities()
        {
            foreach (var ability in Abilities)
            {
                ability.OnActive();
            }
        }

        public void DeActiveAllAbilities()
        {
            foreach (var ability in Abilities)
            {
                ability.OnDeActive();
            }
        }

        [NonSerialized]
        public List<AbilityBase> Abilities;
    }
}