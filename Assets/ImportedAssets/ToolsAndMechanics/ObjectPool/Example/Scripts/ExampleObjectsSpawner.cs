using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Пример спавна объектов
    /// </summary>
    public class ExampleObjectsSpawner : MonoBehaviour
    {
        [SerializeField]
        private float spawnDelay = 1;

        [SerializeField]
        private PoolableObjectData[] datas;
        [SerializeField]
        private Transform[] positions;

        [Inject]
        private ObjectPoolController poolController;

        private IEnumerator Start()
        {
            while (true)
            {
                for (int i = 0; i < datas.Length; i++)
                {
                    poolController.GetObject(datas[i], positions[i].position, true);
                }
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}