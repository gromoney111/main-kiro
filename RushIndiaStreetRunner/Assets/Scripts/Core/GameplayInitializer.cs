using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// AUTO-SETUP for the Gameplay scene.
    /// Place on a single empty GameObject in the Gameplay scene.
    /// It finds/creates all gameplay-specific objects and starts the run.
    /// 
    /// HOW TO USE:
    /// 1. Open Gameplay scene
    /// 2. Create empty GameObject named "_GameplayInit"
    /// 3. Drag this script onto it
    /// 4. The scene will auto-configure when loaded.
    /// </summary>
    public class GameplayInitializer : MonoBehaviour
    {
        [Header("Auto-finds or creates these in scene")]
        [SerializeField] private bool autoCreateSwipeManager = true;
        [SerializeField] private bool autoCreateUIManager = true;
        [SerializeField] private bool autoCreateEnvironmentManager = true;
        [SerializeField] private bool autoCreateObstacleSpawner = true;
        [SerializeField] private bool autoCreatePowerupManager = true;
        [SerializeField] private bool autoCreateObjectPool = true;

        private void Awake()
        {
            EnsureManagersExist();
        }

        private void Start()
        {
            // Start the game after a brief delay for everything to initialize
            Invoke(nameof(StartGameplay), 0.1f);
        }

        private void EnsureManagersExist()
        {
            if (autoCreateSwipeManager && FindObjectOfType<SwipeManager>() == null)
            {
                new GameObject("[SwipeManager]").AddComponent<SwipeManager>();
            }

            if (autoCreateEnvironmentManager && FindObjectOfType<EnvironmentManager>() == null)
            {
                new GameObject("[EnvironmentManager]").AddComponent<EnvironmentManager>();
            }

            if (autoCreateObstacleSpawner && FindObjectOfType<Gameplay.ObstacleSpawner>() == null)
            {
                new GameObject("[ObstacleSpawner]").AddComponent<Gameplay.ObstacleSpawner>();
            }

            if (autoCreatePowerupManager && FindObjectOfType<Gameplay.PowerupManager>() == null)
            {
                new GameObject("[PowerupManager]").AddComponent<Gameplay.PowerupManager>();
            }

            if (autoCreateObjectPool && FindObjectOfType<Utility.ObjectPool>() == null)
            {
                new GameObject("[ObjectPool]").AddComponent<Utility.ObjectPool>();
            }
        }

        /// <summary>
        /// Tell GameManager to start the run.
        /// </summary>
        private void StartGameplay()
        {
            // Hide banner ad during gameplay
            AdManager.Instance?.HideBanner();

            // Reset coin session
            CoinManager.Instance?.ResetSession();

            // Start the game state
            GameManager.Instance?.StartGame();

            // Play gameplay music
            AudioManager.Instance?.PlayGameplayMusic();

            Debug.Log("[GameplayInit] Game started!");
        }
    }
}
