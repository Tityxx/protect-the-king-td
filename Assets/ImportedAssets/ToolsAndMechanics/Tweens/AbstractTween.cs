using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace ToolsAndMechanics.Tweens
{
    public abstract class AbstractTween : MonoBehaviour
    {
        public UnityEvent onStart;
        public UnityEvent onComplete;

        public bool IsCompleted { get; protected set; }
        public Transform Target
        {
            get
            {
                return target == null ? transform : target;
            }
        }

        [SerializeField]
        protected bool ignoreTimeScale;
        [SerializeField]
        protected float duration;
        [SerializeField]
        protected float delay;
        [SerializeField]
        protected Ease easeType = Ease.Linear;
        [SerializeField]
        protected bool canBeInterrupted = true;
        [SerializeField]
        protected bool executeOnEnable;
        [SerializeField]
        protected bool overrideValueOnStart = true;
        [SerializeField]
        protected bool overrideValueOnExecute = true;
        [SerializeField]
        protected LoopType loopType;
        [SerializeField]
        [Tooltip("-1 equals endless")]
        protected int loopCount = 1;
        [SerializeField]
        protected Transform target;

        protected Tween currTween;

        protected virtual void Awake()
        {
            if (overrideValueOnStart)
            {
                ResetValue();
            }
        }

        protected virtual void OnEnable()
        {
            if (executeOnEnable)
            {
                Execute();
            }
        }

        public virtual void Execute(bool straight = true)
        {
            Stop();

            IsCompleted = false;

            if (overrideValueOnExecute)
            {
                ResetValue(straight);
            }

            onStart.Invoke();
        }

        public virtual void Stop()
        {
            if (currTween != null)
            {
                currTween.Rewind();
            }
        }

        public virtual void Kill()
        {
            if (currTween != null)
            {
                currTween.Kill();
            }
        }

        public virtual void Pause()
        {
            if (currTween != null)
            {
                currTween.Pause();
            }
        }

        protected virtual void OnCompleted()
        {
            currTween = null;
            IsCompleted = true;
            onComplete.Invoke();
        }

        protected abstract void ResetValue(bool straight = true);

        [ContextMenu("Execute")]
        private void MenuExecute()
        {
            Execute();
        }

        [ContextMenu("Reverse Execute")]
        private void MenuReverseExecute()
        {
            Execute(false);
        }
    }
}