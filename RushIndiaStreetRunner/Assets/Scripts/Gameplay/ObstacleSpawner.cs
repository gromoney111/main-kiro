using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Spawns obstacles ahead of the player using object pooling.
    /// Difficulty increases over time: spawn rate & variety grow.
    /// City-specific obstacles are loaded from CityData.
    /// </summary>
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private float baseSpawnInterval = 2f;
        [SerializeField] private float minSpawnInterval = 0.5f;
        [SerializeField] private float spawnDistance = 60f; // How far ahead to spawn
        [SerializeField] private float laneWidth = 3f;

        [Header("Obstacle Prefabs")]
        [SerializeField] private GameObject[] commonObstacles;  // Cars, barricades
        [SerializeField] private GameObject[] cityObstacles;    // City-specific (loaded per city)

        [Header("Collectibles")]
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private GameObject gemPrefab;
        [SerializeField] private float coinSpawnChance = 0.6f;
        [SerializeField] private float gemSpawnChance = 0.05f;

        // Runtime
        private float spawnTimer;
        private float currentInterval;
        private Transform playerTransform;
        private List<GameObject> activeObstacles = new List<GameObject>();

        private void Start()
        {
            currentInterval = baseSpawnInterval;

            // Find player
            var player = FindObjectOfType<RushIndia.Core.PlayerController>();
            if (player != null)
                playerTransform = player.transform;
        }

        private void Update()
        {
            if (Core.GameManager.Instance == null) return;
            if (Core.GameManager.Instance.CurrentState != Core.GameState.Playing) return;

            // Scale difficulty
            float difficulty = Core.GameManager.Instance.DifficultyFactor;
            currentInterval = Mathf.Lerp(baseSpawnInterval, minSpawnInterval, difficulty);

            // Spawn timer
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= currentInterval)
            {
                spawnTimer = 0f;
                SpawnObstacleRow();
            }

            // Clean up passed obstacles
            CleanupPassedObstacles();
        }


        /// <summary>
        /// Spawn a row of obstacles/collectibles across lanes.
        /// Ensures at least one lane is always passable.
        /// </summary>
        private void SpawnObstacleRow()
        {
            float spawnZ = GetSpawnZ();

            // Decide how many lanes to block (never all 3)
            int blockedLanes = Random.Range(1, 3); // 1 or 2 lanes blocked
            List<int> lanes = new List<int> { -1, 0, 1 };

            // Shuffle lanes
            for (int i = lanes.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                int temp = lanes[i];
                lanes[i] = lanes[j];
                lanes[j] = temp;
            }

            // Spawn obstacles in blocked lanes
            for (int i = 0; i < blockedLanes; i++)
            {
                SpawnObstacle(lanes[i], spawnZ);
            }

            // Maybe spawn coins in free lane
            if (Random.value < coinSpawnChance)
            {
                SpawnCollectible(lanes[blockedLanes], spawnZ, "Coin");
            }
            else if (Random.value < gemSpawnChance)
            {
                SpawnCollectible(lanes[blockedLanes], spawnZ, "Gem");
            }
        }

        /// <summary>
        /// Spawn a single obstacle at a specific lane and Z position.
        /// </summary>
        private void SpawnObstacle(int lane, float zPos)
        {
            // Choose obstacle type
            GameObject prefab = GetRandomObstaclePrefab();
            if (prefab == null) return;

            // Try to get from pool, fallback to instantiate
            GameObject obstacle = Utility.ObjectPool.Instance != null
                ? Utility.ObjectPool.Instance.Get("Obstacle")
                : Instantiate(prefab);

            if (obstacle == null)
                obstacle = Instantiate(prefab);

            float xPos = lane * laneWidth;
            obstacle.transform.position = new Vector3(xPos, 0f, zPos);
            obstacle.transform.rotation = Quaternion.identity;
            obstacle.tag = "Obstacle";

            activeObstacles.Add(obstacle);
        }

        /// <summary>
        /// Spawn coin or gem collectible.
        /// </summary>
        private void SpawnCollectible(int lane, float zPos, string type)
        {
            GameObject prefab = type == "Coin" ? coinPrefab : gemPrefab;
            if (prefab == null) return;

            string poolTag = type;
            GameObject collectible = Utility.ObjectPool.Instance != null
                ? Utility.ObjectPool.Instance.Get(poolTag)
                : Instantiate(prefab);

            if (collectible == null)
                collectible = Instantiate(prefab);

            float xPos = lane * laneWidth;
            float yPos = type == "Coin" ? 1f : 1.5f;
            collectible.transform.position = new Vector3(xPos, yPos, zPos);
            collectible.tag = type;

            activeObstacles.Add(collectible);
        }

        private GameObject GetRandomObstaclePrefab()
        {
            if (commonObstacles == null || commonObstacles.Length == 0) return null;
            return commonObstacles[Random.Range(0, commonObstacles.Length)];
        }

        private float GetSpawnZ()
        {
            float playerZ = playerTransform != null ? playerTransform.position.z : 0f;
            return playerZ + spawnDistance;
        }

        /// <summary>
        /// Remove obstacles that are far behind the player.
        /// </summary>
        private void CleanupPassedObstacles()
        {
            float playerZ = playerTransform != null ? playerTransform.position.z : 0f;
            float despawnZ = playerZ - 20f;

            for (int i = activeObstacles.Count - 1; i >= 0; i--)
            {
                if (activeObstacles[i] == null)
                {
                    activeObstacles.RemoveAt(i);
                    continue;
                }

                if (activeObstacles[i].transform.position.z < despawnZ)
                {
                    var obj = activeObstacles[i];
                    activeObstacles.RemoveAt(i);

                    // Return to pool or destroy
                    if (Utility.ObjectPool.Instance != null)
                        Utility.ObjectPool.Instance.Return("Obstacle", obj);
                    else
                        Destroy(obj);
                }
            }
        }

        /// <summary>
        /// Set city-specific obstacle prefabs.
        /// </summary>
        public void SetCityObstacles(GameObject[] obstacles)
        {
            cityObstacles = obstacles;
        }

        /// <summary>
        /// Clear all active obstacles (on restart).
        /// </summary>
        public void ClearAll()
        {
            foreach (var obj in activeObstacles)
            {
                if (obj != null)
                {
                    if (Utility.ObjectPool.Instance != null)
                        Utility.ObjectPool.Instance.Return("Obstacle", obj);
                    else
                        Destroy(obj);
                }
            }
            activeObstacles.Clear();
        }
    }
}
