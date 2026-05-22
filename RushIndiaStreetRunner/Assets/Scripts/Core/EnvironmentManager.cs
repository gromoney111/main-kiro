using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Core
{
    /// <summary>
    /// Manages endless road generation using object pooling.
    /// Spawns road segments, decorations, and city-specific elements.
    /// Segments are recycled as the player passes them.
    /// </summary>
    public class EnvironmentManager : MonoBehaviour
    {
        public static EnvironmentManager Instance { get; private set; }

        [Header("Road Segment Settings")]
        [SerializeField] private GameObject roadSegmentPrefab;
        [SerializeField] private int poolSize = 8;
        [SerializeField] private float segmentLength = 30f;

        [Header("City Theming")]
        [SerializeField] private Material defaultRoadMaterial;
        [SerializeField] private Material currentCityRoadMaterial;

        [Header("Decoration Prefabs")]
        [SerializeField] private GameObject[] sideDecorationPrefabs;
        [SerializeField] private GameObject[] backgroundPrefabs;

        [Header("Lighting")]
        [SerializeField] private Light directionalLight;

        // Object pool for road segments
        private Queue<GameObject> segmentPool = new Queue<GameObject>();
        private List<GameObject> activeSegments = new List<GameObject>();
        private float spawnZ;
        private float recycleZ;

        // City configuration reference
        private RushIndia.Data.CityData currentCityData;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            InitializePool();
            SpawnInitialSegments();
        }

        private void Update()
        {
            if (GameManager.Instance == null) return;
            if (GameManager.Instance.CurrentState != GameState.Playing) return;

            // Check if we need to spawn new segments ahead
            CheckAndRecycleSegments();
        }


        /// <summary>
        /// Create road segment pool to avoid runtime instantiation.
        /// </summary>
        private void InitializePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject segment = Instantiate(roadSegmentPrefab, transform);
                segment.SetActive(false);
                segmentPool.Enqueue(segment);
            }
            spawnZ = 0f;
            recycleZ = -segmentLength;
        }

        /// <summary>
        /// Spawn initial road segments visible at game start.
        /// </summary>
        private void SpawnInitialSegments()
        {
            for (int i = 0; i < poolSize - 2; i++)
            {
                SpawnSegment();
            }
        }

        /// <summary>
        /// Spawn a road segment from the pool at the next position.
        /// </summary>
        private void SpawnSegment()
        {
            if (segmentPool.Count == 0) return;

            GameObject segment = segmentPool.Dequeue();
            segment.transform.position = new Vector3(0f, 0f, spawnZ);
            segment.SetActive(true);
            activeSegments.Add(segment);

            spawnZ += segmentLength;
        }

        /// <summary>
        /// Recycle segments that have passed behind the player.
        /// </summary>
        private void CheckAndRecycleSegments()
        {
            if (activeSegments.Count == 0) return;

            // Get player Z position (or camera Z)
            float playerZ = Camera.main != null ? Camera.main.transform.position.z : 0f;

            // Recycle segments that are far behind
            while (activeSegments.Count > 0 &&
                   activeSegments[0].transform.position.z < playerZ + recycleZ)
            {
                GameObject old = activeSegments[0];
                activeSegments.RemoveAt(0);
                old.SetActive(false);
                segmentPool.Enqueue(old);

                // Spawn new segment ahead
                SpawnSegment();
            }
        }

        /// <summary>
        /// Apply city-specific theming (colors, lighting, decorations).
        /// Called when a city is selected.
        /// </summary>
        public void ApplyCityTheme(RushIndia.Data.CityData cityData)
        {
            if (cityData == null) return;
            currentCityData = cityData;

            // Apply road material/color
            if (cityData.roadMaterial != null)
            {
                currentCityRoadMaterial = cityData.roadMaterial;
                // Apply to all active segments
                foreach (var segment in activeSegments)
                {
                    var renderer = segment.GetComponentInChildren<Renderer>();
                    if (renderer != null)
                        renderer.material = currentCityRoadMaterial;
                }
            }

            // Apply lighting
            if (directionalLight != null)
            {
                directionalLight.color = cityData.sunColor;
                directionalLight.intensity = cityData.sunIntensity;
            }

            // Apply fog/atmosphere
            RenderSettings.fog = cityData.hasFog;
            RenderSettings.fogColor = cityData.fogColor;
            RenderSettings.fogDensity = cityData.fogDensity;

            Debug.Log($"[EnvironmentManager] Applied city theme: {cityData.cityName}");
        }

        /// <summary>
        /// Get the current segment length (used by obstacle spawner).
        /// </summary>
        public float GetSegmentLength() => segmentLength;
    }
}
