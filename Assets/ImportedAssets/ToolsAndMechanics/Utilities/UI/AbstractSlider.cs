using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Абстрактый класс слайдера
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public abstract class AbstractSlider : MonoBehaviour
    {
        protected Slider slider;

        protected virtual void Awake()
        {
            slider = GetComponent<Slider>();
        }

        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        public abstract void OnValueChanged(float value);
    }
}