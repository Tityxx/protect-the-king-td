using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace ToolsAndMechanics.Tweens
{
    public class AlphaTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private float startAlpha;
        [SerializeField]
        private float endAlpha;

        private Image image;
        private SpriteRenderer sprite;

        protected override void Awake()
        {
            base.Awake();
            image = Target.GetComponent<Image>();
            sprite = Target.GetComponent<SpriteRenderer>();
        }

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            if (image)
            {
                image.DOColor(GetColor(straight ? endAlpha : startAlpha), duration).
                    SetEase(easeType).
                    SetLoops(loopCount, loopType).
                    SetUpdate(ignoreTimeScale).
                    SetDelay(delay).
                    OnComplete(() => OnCompleted());
            }
            else if (sprite)
            {
                sprite.DOColor(GetColor(straight ? endAlpha : startAlpha), duration).
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
                SetAlpha(startAlpha);
            }
            else
            {
                SetAlpha(endAlpha);
            }
        }

        private void SetAlpha(float value)
        {
            if (image)
            {
                Color c = image.color;
                c.a = value;
                image.color = c;
            }
            else if (sprite)
            {
                Color c = sprite.color;
                c.a = value;
                sprite.color = c;
            }
        }

        private Color GetColor(float alpha)
        {
            Color color = Color.white;

            if (image)
            {
                color = image.color;
            }
            else if (sprite)
            {
                color = sprite.color;
            }
            color.a = alpha;
            return color;
        }
    }
}