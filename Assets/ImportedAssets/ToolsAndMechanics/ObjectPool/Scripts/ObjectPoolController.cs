using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Контроллер пула объектов
    /// </summary>
    public class ObjectPoolController : MonoBehaviour
    {
        [SerializeField]
        private PoolableObjectData[] dataList;

        [Inject]
        private DiContainer container;

        private Dictionary<PoolableObjectData, Queue<GameObject>> queue = new Dictionary<PoolableObjectData, Queue<GameObject>>();

        private void Awake()
        {
            InitPool();
        }

        /// <summary>
        /// Получить объект из пула
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, bool active = true, Transform parent = null)
        {
            GameObject go;

            if (queue.ContainsKey(data))
            {
                if (queue[data].Count > 0)
                {
                    go = queue[data].Dequeue();
                }
                else
                {
                    go = container.InstantiatePrefab(data.Prefab);
                    TryAddInfoInInterface(data, go);
                }
            }
            else
            {
                queue.Add(data, new Queue<GameObject>());
                go = container.InstantiatePrefab(data.Prefab);
                TryAddInfoInInterface(data, go);
            }

            go.transform.SetParent(parent);
            go.SetActive(active);
            return go;
        }

        /// <summary>
        /// Получить объект из пула с указанной позицией
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobal, bool active = true, Transform parent = null)
        {
            GameObject go = GetObject(data, false, parent);

            if (isGlobal) go.transform.position = position;
            else go.transform.localPosition = position;

            go.SetActive(active);
            return go;
        }

        /// <summary>
        /// Получить объект из пула с указанной позицией и поворотом
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobalPosition, Vector3 eulerAngles, bool isGlobalRotation, bool active = true, Transform parent = null)
        {
            GameObject go = GetObject(data, false, parent);

            if (isGlobalPosition) go.transform.position = position;
            else go.transform.localPosition = position;
            if (isGlobalRotation) go.transform.eulerAngles = eulerAngles;
            else go.transform.localEulerAngles = eulerAngles;

            go.SetActive(active);
            return go;
        }

        /// <summary>
        /// Вернуть объект в пул
        /// </summary>
        public void ReturnObject(GameObject go, PoolableObjectData data)
        {
            go.SetActive(false);
            go.transform.parent = null;
            if (queue.ContainsKey(data))
            {
                queue[data].Enqueue(go);
            }
            else
            {
                queue.Add(data, new Queue<GameObject>(new[] { go }));
            }
        }

        private void InitPool()
        {
            foreach (PoolableObjectData data in dataList)
            {
                queue.Add(data, new Queue<GameObject>());
                for (int i = 0; i < data.InitCount; i++)
                {
                    GameObject go = container.InstantiatePrefab(data.Prefab);
                    TryAddInfoInInterface(data, go);
                    go.SetActive(false);
                    queue[data].Enqueue(go);
                }
            }
        }

        private void TryAddInfoInInterface(PoolableObjectData data, GameObject go)
        {
            if (go.TryGetComponent(out IPoolableObject obj))
            {
                obj.InitPoolableObject(this, data);
            }
        }
    }
}