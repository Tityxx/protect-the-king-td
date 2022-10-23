using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.Utilities
{
    public class TimeScaleEnabler : MonoBehaviour
    {
        [SerializeField]
        private float enableTimeScale = 0f;
        [SerializeField]
        private float disableTimeScale = 1f;

        private void OnEnable()
        {
            Time.timeScale = enableTimeScale;
        }

        private void OnDisable()
        {
            Time.timeScale = disableTimeScale;
        }
    }
}