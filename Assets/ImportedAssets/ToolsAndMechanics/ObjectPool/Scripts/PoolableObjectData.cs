using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Данные объекта для пула
    /// </summary>
    [CreateAssetMenu(menuName = "ToolsAndMechanics/Object Pool/Poolable Object Data", fileName = "New ObjectData")]
    public class PoolableObjectData : ScriptableObject
    {
        public int InitCount => initCount;
        public GameObject Prefab => prefab;

        [SerializeField]
        private int initCount = 10;
        [SerializeField]
        private GameObject prefab;
    }
}