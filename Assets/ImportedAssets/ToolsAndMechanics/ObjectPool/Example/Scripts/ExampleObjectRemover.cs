using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Пример возврата объекта в пул
    /// </summary>
    public class ExampleObjectRemover : MonoBehaviour, IPoolableObject
    {
        [SerializeField]
        private float delay = 1f;

        private ObjectPoolController pool;

        private PoolableObjectData poolableObjectData;

        private void OnEnable()
        {
            StartCoroutine(RemoveObjectWithDelay(delay));
        }

        private IEnumerator RemoveObjectWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            pool.ReturnObject(gameObject, poolableObjectData);
        }

        public void InitPoolableObject(ObjectPoolController pool, PoolableObjectData data)
        {
            this.pool = pool;
            poolableObjectData = data;
        }
    }
}