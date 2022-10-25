using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using ToolsAndMechanics.Utilities;
using UnityEngine;

namespace ToolsAndMechanics.Tweens
{
    public class TweensButton : AbstractButton
    {
        [SerializeField]
        private bool straight;
        [SerializeField]
        private List<GameObject> enableObjects;
        [SerializeField]
        private List<GameObject> disableObjects;
        [SerializeField]
        private List<AbstractTween> tweens;

        public override void OnButtonClick()
        {
            enableObjects.SetActive(true);
            disableObjects.SetActive(false);

            foreach (var t in tweens)
            {
                t.Execute(straight);
            }
        }
    }
}