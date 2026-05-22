using UnityEngine;
using UnityEngine.SceneManagement;

namespace RushIndia.Core
{
    /// <summary>
    /// AUTO-SETUP: Place this script on a single empty GameObject in your FIRST scene (LoadingScene).
    /// It automatically creates ALL required manager singletons so you never get null reference errors.
    /// This is the ONLY setup needed - everything else auto-configures.
    /// 
    /// HOW TO USE:
    /// 1. Open LoadingScene
    /// 2. Create empty GameObject, name it "_GameBootstrapper"
    /// 3. Drag this script onto it
    /// 4. Done! All managers will auto-create when the game starts.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("This script auto-creates all game managers")]
        [SerializeField] private bool showDebugLogs = true;

        private static bool hasBooted = false;

        private void Awake()
        {
            // Only boot once ever
            if (hasBooted)
            {
                Destroy(gameObject);
                return;
            }
            hasBooted = true;
            DontDestroyOnLoad(gameObject);

            if (showDebugLogs)
                Debug.Log("[GameBootstrapper] Initializing Rush India: Street Runner...");

            CreateManagers();

            if (showDebugLogs)
                Debug.Log("[GameBootstrapper] All managers ready!");
        }

        /// <summary>
        /// Creates all singleton managers that persist across scenes.
        /// Order matters! Some managers depend on others.
        /// </summary>
        private void CreateManagers()
        {
            // 1. SaveManager FIRST (others depend on saved data)
            CreateManager<SaveManager>("SaveManager");

            // 2. GameManager (central game state)
            CreateManager<GameManager>("GameManager");

            // 3. AudioManager (music & SFX)
            CreateManager<AudioManager>("AudioManager");

            // 4. CoinManager (currency - needs SaveManager)
            CreateManager<CoinManager>("CoinManager");

            // 5. AdManager (advertisements)
            CreateManager<AdManager>("AdManager");

            // 6. Gameplay managers
            CreateManager<Gameplay.DailyRewardManager>("DailyRewardManager");
            CreateManager<Gameplay.MissionManager>("MissionManager");
            CreateManager<Gameplay.LeaderboardManager>("LeaderboardManager");
            CreateManager<Gameplay.IAPManager>("IAPManager");
        }

        /// <summary>
        /// Creates a manager if one doesn't already exist in the scene.
        /// </summary>
        private void CreateManager<T>(string name) where T : MonoBehaviour
        {
            if (FindObjectOfType<T>() != null)
            {
                if (showDebugLogs)
                    Debug.Log($"  [Boot] {name} already exists, skipping.");
                return;
            }

            GameObject obj = new GameObject($"[{name}]");
            obj.AddComponent<T>();
            DontDestroyOnLoad(obj);

            if (showDebugLogs)
                Debug.Log($"  [Boot] Created {name} ✓");
        }
    }
}
