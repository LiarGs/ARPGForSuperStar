/* 技能基类 By ashenguo
   2025/7/4
*/

namespace GameCore.Code.BaseClass
{
    public abstract class AbilityBase
    {
        public abstract void OnActive();
        public abstract void OnDeActive();
        
        public bool IsActive { get; protected set; }
    }
}