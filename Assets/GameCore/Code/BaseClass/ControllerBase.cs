/* 处理外部输入 By ashenguo
   2025/7/4
*/

using System;
using UnityEngine;

namespace GameCore.Code.BaseClass
{
   public abstract class ControllerBase : MonoBehaviour
   {
      public InputControl InputController;
      
      protected virtual void Awake()
      {
         InputController = new InputControl();
      }

      protected virtual void OnEnable()
      {
         InputController.Enable();
      }

      protected virtual void OnDisable()
      {
         InputController.Disable();
      }

      [NonSerialized]
      public float VerticalInput;
      [NonSerialized]
      public float HorizontalInput;
      [NonSerialized]
      public float MoveAmount;
   }
}