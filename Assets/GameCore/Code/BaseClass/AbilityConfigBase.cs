/* 技能配置基类 By ashenguo
   2025/7/4
*/

using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    public abstract class AbilityConfigBase : ScriptableObject
    {
        private void OnEnable()
        {
            if (string.IsNullOrEmpty(Label)) Label = name;
            Effects ??= new List<AbilityEffectBase>();
        }

        protected virtual void OnActive()
        {
        }

        protected virtual void OnDeActive()
        {
        }

        public bool IsActive
        {
            get => _IsActive;
            set
            {
                _IsActive = value;
                if (_IsActive)
                {
                    OnActive();
                }
                else
                {
                    OnDeActive();
                }
            }
        }

        public string Label;
        private bool _IsActive;
        [SerializeReference] public List<AbilityEffectBase> Effects;
    }
}