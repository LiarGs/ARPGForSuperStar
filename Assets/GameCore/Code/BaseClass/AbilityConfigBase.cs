/* 技能配置基类 By ashenguo
   2025/7/4
*/

using System;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
    // [CreateAssetMenu(fileName = "NewData", menuName = "Custom Data/Example Data")]
    public abstract class AbilityConfigBase : ScriptableObject, IDisposable
    {
        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}