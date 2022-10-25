using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToolsAndMechanics.Tweens
{
    public class MoveTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private bool useLocalSpace = true;
        [SerializeField]
        private Vector3 startPosition;
        [SerializeField]
        private Vector3 endPosition;

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            if (useLocalSpace)
            {
                currTween = Target.DOLocalMove(straight ? endPosition : startPosition, duration).
                    SetEase(easeType).
                    SetLoops(loopCount, loopType).
                    SetUpdate(ignoreTimeScale).
                    SetDelay(delay).
                    OnComplete(() => OnCompleted());
            }
            else
            {
                currTween = Target.DOMove(straight ? endPosition : startPosition, duration).
                    SetEase(easeType).
                    SetLoops(loopCount, loopType).
                    SetUpdate(ignoreTimeScale).
                    SetDelay(delay).
                    OnComplete(() => OnCompleted());
            }
        }

        protected override void ResetValue(bool straight = true)
        {
            if (useLocalSpace)
            {
                Target.localPosition = straight ? startPosition : endPosition;
            }
            else
            {
                Target.position = straight ? startPosition : endPosition;
            }
        }
    }
}