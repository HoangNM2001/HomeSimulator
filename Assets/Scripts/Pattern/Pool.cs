using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Pattern
{
    public class Pool<T> : ScriptableObject where T : Object
    {
        private T _poolObject;
        private ObjectPool<T> _objectPool;

        private void Awake()
        {
            // _objectPool = new ObjectPool<T>(CreateObject, OnTakeObjectFromPool, OnReturnObjectToPool,
                // OnDestroyObject, true, 1000, 1500);
        }

        // protected T CreateObject()
        // {
        //     var newObject = Instantiate(_poolObject) as PoolObject;
        //
        //     newObject.SetPool(_objectPool);
        //     
        //     return newObject;
        // }

        private void OnTakeObjectFromPool(T poolObj)
        {
            // poolObj.gameObject.SetActive(true);
            // poolObj.OnTakeFromPool();
        }

        private void OnReturnObjectToPool(T poolObj)
        {
            // poolObj.gameObject.SetActive(false);
            // poolObj.OnReturnToPool();
        }

        private void OnDestroyObject(PoolObject poolObj)
        {
            // Destroy(poolObj);
        }
    }
}