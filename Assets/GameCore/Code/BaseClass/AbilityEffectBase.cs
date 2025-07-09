/* 技能特效基类 By ashenguo
   2025/7/9
*/

using System;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    [Serializable]
    public abstract class AbilityEffectBase
    {
        public abstract void Execute(GameObject caster, GameObject target);
    }
}