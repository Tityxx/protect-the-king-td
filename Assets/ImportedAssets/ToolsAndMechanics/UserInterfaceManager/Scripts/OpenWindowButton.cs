using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Кнопка открытия окна
    /// </summary>
    public class OpenWindowButton : AbstractButton
    {
        [SerializeField]
        private WindowData window;
        [SerializeField]
        private bool closeCurrentWindow;

        private WindowsController controller;

        protected override void OnEnable()
        {
            base.OnEnable();
            btn.interactable = true;
        }

        public override void OnButtonClick()
        {
            if (closeCurrentWindow)
                btn.interactable = false;
            controller.SetWindow(window, closeCurrentWindow);
        }

        public void SetController(WindowsController controller)
        {
            this.controller = controller;
        }
    }
}