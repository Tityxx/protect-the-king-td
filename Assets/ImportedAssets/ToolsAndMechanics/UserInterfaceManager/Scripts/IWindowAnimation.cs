using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Интерфейс для анимации открытия/закрытия окон
    /// </summary>
    public interface IWindowAnimation
    {
        /// <summary>
        /// Открытие окна
        /// </summary>
        public void OpenWindow();

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public void CloseWindow(Action action);
    }
}