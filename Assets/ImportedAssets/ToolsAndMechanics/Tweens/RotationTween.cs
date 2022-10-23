using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToolsAndMechanics.Tweens
{
    public class RotationTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private RotateMode rotateMode = RotateMode.FastBeyond360;
        [SerializeField]
        private Vector3 startRotation;
        [SerializeField]
        private Vector3 endRotation;

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            currTween = transform.DOLocalRotate(straight ? endRotation : startRotation, duration, rotateMode).
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
                transform.localEulerAngles = startRotation;
            }
            else
            {
                transform.localEulerAngles = endRotation;
            }
        }
    }
}