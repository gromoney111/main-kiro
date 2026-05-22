using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Manages daily/weekly missions (e.g., "Collect 100 coins", "Run 500m").
    /// Missions give bonus rewards and keep players engaged.
    /// </summary>
    public class MissionManager : MonoBehaviour
    {
        public static MissionManager Instance { get; private set; }

        [System.Serializable]
        public class Mission
        {
            public string id;
            public string description;
            public MissionType type;
            public int targetAmount;
            public int currentProgress;
            public int rewardCoins;
            public int rewardGems;
            public bool isCompleted;
        }

        public enum MissionType
        {
            CollectCoins,
            CollectGems,
            RunDistance,
            CollectPowerups,
            PlayGames,
            ScorePoints,
            UseCharacter
        }

        [Header("Active Missions")]
        [SerializeField] private int maxActiveMissions = 3;

        private List<Mission> activeMissions = new List<Mission>();

        // Events
        public System.Action<Mission> OnMissionCompleted;
        public System.Action<Mission> OnMissionProgress;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadOrGenerateMissions();
        }

        /// <summary>
        /// Load saved missions or generate new daily ones.
        /// </summary>
        private void LoadOrGenerateMissions()
        {
            // TODO: Load from PlayerPrefs/JSON
            // For now, generate sample missions
            if (activeMissions.Count == 0)
            {
                GenerateDailyMissions();
            }
        }

        /// <summary>
        /// Generate random daily missions.
        /// </summary>
        private void GenerateDailyMissions()
        {
            activeMissions.Clear();

            activeMissions.Add(new Mission
            {
                id = "daily_coins",
                description = "Collect 50 coins in a single run",
                type = MissionType.CollectCoins,
                targetAmount = 50,
                currentProgress = 0,
                rewardCoins = 100,
                rewardGems = 0,
                isCompleted = false
            });

            activeMissions.Add(new Mission
            {
                id = "daily_distance",
                description = "Run 500 meters",
                type = MissionType.RunDistance,
                targetAmount = 500,
                currentProgress = 0,
                rewardCoins = 50,
                rewardGems = 1,
                isCompleted = false
            });

            activeMissions.Add(new Mission
            {
                id = "daily_score",
                description = "Score 5000 points",
                type = MissionType.ScorePoints,
                targetAmount = 5000,
                currentProgress = 0,
                rewardCoins = 75,
                rewardGems = 2,
                isCompleted = false
            });
        }

        /// <summary>
        /// Report progress on a mission type. Called by other systems.
        /// </summary>
        public void ReportProgress(MissionType type, int amount)
        {
            foreach (var mission in activeMissions)
            {
                if (mission.isCompleted) continue;
                if (mission.type != type) continue;

                mission.currentProgress += amount;
                OnMissionProgress?.Invoke(mission);

                if (mission.currentProgress >= mission.targetAmount)
                {
                    CompleteMission(mission);
                }
            }
        }

        private void CompleteMission(Mission mission)
        {
            mission.isCompleted = true;

            // Grant rewards
            Core.CoinManager.Instance?.AddCoins(mission.rewardCoins);
            Core.CoinManager.Instance?.AddGems(mission.rewardGems);

            OnMissionCompleted?.Invoke(mission);
            Debug.Log($"[MissionManager] Completed: {mission.description}");
        }

        /// <summary>
        /// Get all active missions for UI display.
        /// </summary>
        public List<Mission> GetActiveMissions() => activeMissions;
    }
}
