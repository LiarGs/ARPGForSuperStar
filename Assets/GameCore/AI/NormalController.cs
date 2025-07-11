/* AI Controller By ashenguo
   2025/7/11
*/

using GameCore.Code.BaseClass;
using UnityEngine;

namespace GameCore.AI
{
    public class NormalController : ActorControllerBase
    {
        public override Vector3 Forward { get; }
        public override Vector3 Right { get; }
        public override float MoveAmount { get; }
        public override float VerticalInput { get; }
        public override float HorizontalInput { get; }
    }
}