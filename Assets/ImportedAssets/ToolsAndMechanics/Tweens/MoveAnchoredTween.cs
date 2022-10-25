using DG.Tweening;
using UnityEngine;

namespace ToolsAndMechanics.Tweens
{
    public class MoveAnchoredTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private Vector2 startPosition;
        [SerializeField]
        private Vector2 endPosition;

        private RectTransform rect => Target as RectTransform;

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            if (straight)
            {
                currTween = rect.DOAnchorPos(endPosition, duration).
                    SetEase(easeType).
                    SetLoops(loopCount, loopType).
                    SetUpdate(ignoreTimeScale).
                    SetDelay(delay).
                    OnComplete(() => OnCompleted());
            }
            else
            {
                currTween = rect.DOAnchorPos(startPosition, duration).
                    SetEase(easeType).
                    SetLoops(loopCount, loopType).
                    SetUpdate(ignoreTimeScale).
                    SetDelay(delay).
                    OnComplete(() => OnCompleted());
            }
        }

        protected override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                rect.anchoredPosition = startPosition;
            }
            else
            {
                rect.anchoredPosition = endPosition;
            }
        }
    }
}