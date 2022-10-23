using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.UserInterfaceManager
{
    /// <summary>
    /// Данные об окне
    /// </summary>
    [CreateAssetMenu(menuName = "ToolsAndMechanics/UserInterfaceManager/Window Data", fileName = "New Window")]
    public class WindowData : ScriptableObject
    {
        public string Id => id;
        public Window WindowPrefab => windowPrefab;

        [SerializeField]
        private string id;
        [SerializeField]
        private Window windowPrefab;
    }
}