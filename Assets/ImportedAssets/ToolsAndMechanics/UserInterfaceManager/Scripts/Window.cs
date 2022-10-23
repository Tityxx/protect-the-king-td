using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Префаб окна
    /// </summary>
    public class Window : MonoBehaviour
    {
        [HideInInspector]
        public bool IsFocus = false;

        private IWindowAnimation anim;

        private void Awake()
        {
            anim = GetComponent<IWindowAnimation>();
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        public void CloseWindow(Action action)
        {
            if (anim != null)
            {
                anim.CloseWindow(action);
            }
            else
            {
                action?.Invoke();
            }
        }
    }
}