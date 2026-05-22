using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Utility
{
    /// <summary>
    /// Generic object pooling system for mobile performance.
    /// Avoids Instantiate/Destroy calls during gameplay which cause GC spikes.
    /// Usage: Create a pool for each prefab type (coins, obstacles, effects).
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        [System.Serializable]
        public class PoolConfig
        {
            public string tag;           // Identifier for this pool
            public GameObject prefab;    // Prefab to pool
            public int initialSize = 10; // Pre-spawn count
            public bool expandable = true; // Allow growing beyond initial size
        }

        public static ObjectPool Instance { get; private set; }

        [Header("Pool Configurations")]
        [SerializeField] private PoolConfig[] poolConfigs;

        // Dictionary of pools by tag
        private Dictionary<string, Queue<GameObject>> pools;
        private Dictionary<string, PoolConfig> configMap;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            InitializePools();
        }

        /// <summary>
        /// Pre-instantiate all pool objects at startup.
        /// This front-loads allocation cost to loading screen.
        /// </summary>
        private void InitializePools()
        {
            pools = new Dictionary<string, Queue<GameObject>>();
            configMap = new Dictionary<string, PoolConfig>();

            foreach (var config in poolConfigs)
            {
                var queue = new Queue<GameObject>();

                for (int i = 0; i < config.initialSize; i++)
                {
                    GameObject obj = CreatePoolObject(config.prefab);
                    queue.Enqueue(obj);
                }

                pools[config.tag] = queue;
                configMap[config.tag] = config;
            }
        }


        /// <summary>
        /// Get an object from the pool. Returns null if pool is empty and not expandable.
        /// </summary>
        public GameObject Get(string tag)
        {
            if (!pools.ContainsKey(tag))
            {
                Debug.LogWarning($"[ObjectPool] No pool with tag: {tag}");
                return null;
            }

            var queue = pools[tag];

            if (queue.Count > 0)
            {
                GameObject obj = queue.Dequeue();
                obj.SetActive(true);
                return obj;
            }

            // Pool empty - expand if allowed
            if (configMap[tag].expandable)
            {
                GameObject obj = CreatePoolObject(configMap[tag].prefab);
                obj.SetActive(true);
                return obj;
            }

            Debug.LogWarning($"[ObjectPool] Pool '{tag}' exhausted and not expandable");
            return null;
        }

        /// <summary>
        /// Return an object to the pool. Disables it and re-queues.
        /// </summary>
        public void Return(string tag, GameObject obj)
        {
            if (obj == null) return;

            obj.SetActive(false);
            obj.transform.SetParent(transform);

            if (pools.ContainsKey(tag))
            {
                pools[tag].Enqueue(obj);
            }
            else
            {
                // Fallback: just destroy if pool doesn't exist
                Destroy(obj);
            }
        }

        /// <summary>
        /// Return all active objects of a pool type (e.g., on game restart).
        /// </summary>
        public void ReturnAll(string tag)
        {
            // This requires tracking active objects externally
            // Typically called via ObstacleSpawner which tracks its own spawned objects
            Debug.Log($"[ObjectPool] ReturnAll called for: {tag}");
        }

        private GameObject CreatePoolObject(GameObject prefab)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            return obj;
        }

        /// <summary>
        /// Get current available count for a pool.
        /// Useful for debugging pool sizes.
        /// </summary>
        public int GetAvailableCount(string tag)
        {
            return pools.ContainsKey(tag) ? pools[tag].Count : 0;
        }
    }
}
