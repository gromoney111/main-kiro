using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Local leaderboard manager - stores top scores locally.
    /// Stub-ready for future online leaderboard integration
    /// (Google Play Games, Firebase, etc.).
    /// </summary>
    public class LeaderboardManager : MonoBehaviour
    {
        public static LeaderboardManager Instance { get; private set; }

        [System.Serializable]
        public class LeaderboardEntry
        {
            public string playerName;
            public int score;
            public string cityId;
            public string date;
        }

        [Header("Settings")]
        [SerializeField] private int maxEntries = 10;

        private const string LEADERBOARD_KEY = "ri_leaderboard";
        private List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

        // Events
        public System.Action<List<LeaderboardEntry>> OnLeaderboardUpdated;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadLeaderboard();
        }

        /// <summary>
        /// Submit a new score to the local leaderboard.
        /// </summary>
        public void SubmitScore(int score, string cityId)
        {
            var entry = new LeaderboardEntry
            {
                playerName = "Player", // TODO: Add player name input
                score = score,
                cityId = cityId,
                date = System.DateTime.Now.ToString("yyyy-MM-dd")
            };

            entries.Add(entry);

            // Sort descending by score
            entries.Sort((a, b) => b.score.CompareTo(a.score));

            // Trim to max entries
            if (entries.Count > maxEntries)
                entries.RemoveRange(maxEntries, entries.Count - maxEntries);

            SaveLeaderboard();
            OnLeaderboardUpdated?.Invoke(entries);
        }

        /// <summary>
        /// Get all leaderboard entries (sorted by score desc).
        /// </summary>
        public List<LeaderboardEntry> GetEntries() => entries;

        /// <summary>
        /// Get the player's best score.
        /// </summary>
        public int GetBestScore()
        {
            return entries.Count > 0 ? entries[0].score : 0;
        }

        private void SaveLeaderboard()
        {
            string json = JsonUtility.ToJson(new LeaderboardWrapper { entries = entries });
            PlayerPrefs.SetString(LEADERBOARD_KEY, json);
            PlayerPrefs.Save();
        }

        private void LoadLeaderboard()
        {
            string json = PlayerPrefs.GetString(LEADERBOARD_KEY, "");
            if (!string.IsNullOrEmpty(json))
            {
                var wrapper = JsonUtility.FromJson<LeaderboardWrapper>(json);
                if (wrapper != null && wrapper.entries != null)
                    entries = wrapper.entries;
            }
        }

        // Wrapper class needed for JsonUtility list serialization
        [System.Serializable]
        private class LeaderboardWrapper
        {
            public List<LeaderboardEntry> entries;
        }

        /// <summary>
        /// TODO: Stub for online leaderboard integration.
        /// Replace with Google Play Games or Firebase implementation.
        /// </summary>
        public void SubmitToOnlineLeaderboard(int score)
        {
            Debug.Log($"[Leaderboard] TODO: Submit {score} to online leaderboard");
            // TODO: Implement Google Play Games Services
            // PlayGamesPlatform.Instance.ReportScore(score, "leaderboard_id", (success) => { });
        }
    }
}
