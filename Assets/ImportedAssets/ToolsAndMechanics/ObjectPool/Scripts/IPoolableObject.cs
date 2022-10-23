using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.ObjectPool
{
    public interface IPoolableObject
    {
        public void InitPoolableObject(ObjectPoolController pool, PoolableObjectData data);
    }
}