using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Абстрактый класс текста
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class AbstractText : MonoBehaviour
    {
        protected TMP_Text text;

        protected virtual void Awake()
        {
            text = GetComponent<TMP_Text>();
        }
    }
}