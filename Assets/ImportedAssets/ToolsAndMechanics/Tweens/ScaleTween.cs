using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToolsAndMechanics.Tweens
{
    public class ScaleTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private Vector3 startScale;
        [SerializeField]
        private Vector3 endScale;

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            currTween = transform.DOScale(straight ? endScale : startScale, duration).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                SetUpdate(ignoreTimeScale).
                SetDelay(delay).
                OnComplete(() => OnCompleted());
        }

        protected override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                transform.localScale = startScale;
            }
            else
            {
                transform.localScale = endScale;
            }
        }
    }
}