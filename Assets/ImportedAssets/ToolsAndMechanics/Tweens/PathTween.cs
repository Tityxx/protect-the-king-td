using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToolsAndMechanics.Tweens
{
    public class PathTween : AbstractTween
    {
        [Space]
        [SerializeField]
        private PathType pathType;
        [SerializeField]
        private PathMode pathMode;
        [SerializeField]
        private List<Transform> path;

        private Vector3 startPosition;
        private Quaternion startRotation;
        private List<Vector3> pathPos = new List<Vector3>();
        private List<Vector3> pathPosReverse = new List<Vector3>();

        protected override void Awake()
        {
            base.Awake();

            startPosition = Target.position;
            startRotation = Target.rotation;

            foreach (Transform t in path)
            {
                pathPos.Add(t.position);
                pathPosReverse.Add(t.position);
            }
            pathPosReverse.Reverse();
        }

        public override void Execute(bool straight = true)
        {
            if (currTween != null)
            {
                if (currTween.IsPlaying() && !canBeInterrupted) return;
            }

            base.Execute(straight);

            currTween = Target.DOPath(straight ? pathPos.ToArray() : pathPosReverse.ToArray(), duration, pathType, pathMode).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                SetUpdate(ignoreTimeScale).
                SetDelay(delay).
                OnComplete(() => OnCompleted());
        }

        protected override void ResetValue(bool straight = true)
        {
            Target.position = startPosition;
            Target.rotation = startRotation;
        }
    }
}