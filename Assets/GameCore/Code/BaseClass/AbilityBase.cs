/* 技能基类 By ashenguo
   2025/7/4
*/

using System;
using System.Collections.Generic;

namespace GameCore.Code.BaseClass
{
    [Serializable]
    public abstract class AbilityBase
    {
        public virtual void OnActive()
        {
        }

        public virtual void OnDeActive()
        {
        }

        public virtual void Execute()
        {
        }

        public List<AbilityEffectBase> Effects;
    }
}