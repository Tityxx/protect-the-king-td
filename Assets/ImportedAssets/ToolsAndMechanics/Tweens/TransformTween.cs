using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToolsAndMechanics.Tweens
{
    public class TransformTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private bool needMove;
        [SerializeField]
        private bool needRotate;
        [SerializeField]
        private bool needScale;
        [SerializeField]
        private Transform start;
        [SerializeField]
        private Transform end;

        private Tween rotationTween;
        private Tween scaleTween;

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }
            if (rotationTween != null)
            {
                if (rotationTween.IsPlaying() && !canBeInterrupted) return;
            }
            if (scaleTween != null)
            {
                if (scaleTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            currTween = transform.DOLocalMove(straight ? end.localPosition : start.position, duration).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                SetUpdate(ignoreTimeScale).
                SetDelay(delay).
                OnComplete(() => OnCompleted());

            rotationTween = transform.DORotate(straight ? end.eulerAngles : start.eulerAngles, duration, RotateMode.FastBeyond360).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                SetUpdate(ignoreTimeScale).
                SetDelay(delay);

            scaleTween = transform.DOScale(straight ? end.localScale : start.localScale, duration).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                SetUpdate(ignoreTimeScale).
                SetDelay(delay);
        }

        public override void Stop()
        {
            base.Stop();
            if (rotationTween != null)
            {
                rotationTween.Rewind();
            }
            if (scaleTween != null)
            {
                scaleTween.Rewind();
            }
        }

        public override void Kill()
        {
            base.Kill();
            if (rotationTween != null)
            {
                rotationTween.Kill();
            }
            if (scaleTween != null)
            {
                scaleTween.Kill();
            }
        }

        public override void Pause()
        {
            base.Pause();
            if (rotationTween != null)
            {
                rotationTween.Pause();
            }
            if (scaleTween != null)
            {
                scaleTween.Pause();
            }
        }

        protected override void OnCompleted()
        {
            rotationTween = null;
            scaleTween = null;
            base.OnCompleted();
        }

        protected override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                if (needMove) transform.position = start.position;
                if (needRotate) transform.rotation = start.rotation;
                if (needScale) transform.localScale = start.localScale;
            }
            else
            {
                if (needMove) transform.position = end.position;
                if (needRotate) transform.rotation = end.rotation;
                if (needScale) transform.localScale = end.localScale;
            }
        }
    }
}