using UnityEngine.Pool;

namespace Extensions
{
    public static class ObjectPoolExtensions
    {
        public static void Prewarm<T>(this ObjectPool<T> pool, int prewarmCount) where T : class
        {
            var poolObjects = new T[prewarmCount];
            for (var i = 0; i < prewarmCount; i++) 
                poolObjects[i] = pool.Get();

            foreach (var poolObject in poolObjects) 
                pool.Release(poolObject);
        }
    }
}
