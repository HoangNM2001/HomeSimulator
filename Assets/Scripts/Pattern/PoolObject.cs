using UnityEngine;
using UnityEngine.Pool;

namespace Pattern
{
    public class PoolObject : MonoBehaviour
    {
        private ObjectPool<PoolObject> _pool;
        
        public void SetPool(ObjectPool<PoolObject> pool)
        {
            _pool = pool;
        }
        
        public virtual void OnTakeFromPool()
        {
        
        }

        public virtual void OnReturnToPool()
        {
            
        }
    }
}
