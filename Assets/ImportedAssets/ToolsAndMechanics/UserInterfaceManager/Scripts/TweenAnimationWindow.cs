using System;
using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.Tweens;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Реализация интерфейса для анимаций
    /// закрытия/открытия окон через твины
    /// </summary>
    public class TweenAnimationWindow : MonoBehaviour, IWindowAnimation
    {
        [SerializeField]
        private AbstractTween[] tweens;

        private void OnEnable()
        {
            OpenWindow();
        }

        public void OpenWindow()
        {
            AnimTweens(true);
        }

        public void CloseWindow(Action action)
        {
            AnimTweens(false);
            StartCoroutine(CloseWindowWithDelay(action));
        }

        private IEnumerator CloseWindowWithDelay(Action action)
        {
            yield return new WaitUntil(() => AllTweensCompleted());
            action?.Invoke();
        }

        private void AnimTweens(bool straight)
        {
            foreach (var t in tweens)
            {
                t.Execute(straight);
            }
        }

        private bool AllTweensCompleted()
        {
            foreach (var t in tweens)
            {
                if (!t.IsCompleted) return false;
            }
            return true;
        }
    }
}