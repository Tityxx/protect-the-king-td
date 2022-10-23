using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Реализация интерфейса для анимаций
    /// закрытия/открытия окон
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimationWindow : MonoBehaviour, IWindowAnimation
    {
        [SerializeField]
        private string animOpenKey = "IsOpen";
        [SerializeField]
        private float closeAnimTime;

        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            OpenWindow();
        }

        public void OpenWindow()
        {
            anim.SetBool(animOpenKey, true);
        }

        public void CloseWindow(Action action)
        {
            anim.SetBool(animOpenKey, false);
            StartCoroutine(CloseWindowWithDelay(action));
        }

        private IEnumerator CloseWindowWithDelay(Action action)
        {
            yield return new WaitForSecondsRealtime(closeAnimTime);
            action?.Invoke();
        }
    }
}