using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Handles all persistent data saving/loading using PlayerPrefs.
    /// For production, consider migrating to JSON file-based saves
    /// for better data integrity and backup support.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        // PlayerPrefs keys - centralized to avoid typos
        private const string KEY_COINS = "ri_coins";
        private const string KEY_GEMS = "ri_gems";
        private const string KEY_HIGH_SCORE = "ri_highscore";
        private const string KEY_ADS_REMOVED = "ri_ads_removed";
        private const string KEY_SOUND_ON = "ri_sound";
        private const string KEY_MUSIC_ON = "ri_music";
        private const string KEY_SELECTED_CHARACTER = "ri_character";
        private const string KEY_DAILY_REWARD_DAY = "ri_daily_day";
        private const string KEY_DAILY_REWARD_TIMESTAMP = "ri_daily_ts";
        private const string KEY_TOTAL_GAMES = "ri_total_games";
        private const string KEY_UNLOCKED_CHARS = "ri_unlocked_chars";

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


        #region Currency

        public void SaveCoins(int amount) => PlayerPrefs.SetInt(KEY_COINS, amount);
        public int GetCoins() => PlayerPrefs.GetInt(KEY_COINS, 0);

        public void SaveGems(int amount) => PlayerPrefs.SetInt(KEY_GEMS, amount);
        public int GetGems() => PlayerPrefs.GetInt(KEY_GEMS, 0);

        #endregion

        #region Score

        public void SaveHighScore(int score)
        {
            int current = GetHighScore();
            if (score > current)
            {
                PlayerPrefs.SetInt(KEY_HIGH_SCORE, score);
                PlayerPrefs.Save();
            }
        }

        public int GetHighScore() => PlayerPrefs.GetInt(KEY_HIGH_SCORE, 0);

        #endregion

        #region Settings

        public void SetSoundEnabled(bool enabled)
        {
            PlayerPrefs.SetInt(KEY_SOUND_ON, enabled ? 1 : 0);
            PlayerPrefs.Save();
        }

        public bool IsSoundEnabled() => PlayerPrefs.GetInt(KEY_SOUND_ON, 1) == 1;

        public void SetMusicEnabled(bool enabled)
        {
            PlayerPrefs.SetInt(KEY_MUSIC_ON, enabled ? 1 : 0);
            PlayerPrefs.Save();
        }

        public bool IsMusicEnabled() => PlayerPrefs.GetInt(KEY_MUSIC_ON, 1) == 1;

        public void SetAdsRemoved(bool removed)
        {
            PlayerPrefs.SetInt(KEY_ADS_REMOVED, removed ? 1 : 0);
            PlayerPrefs.Save();
        }

        public bool AreAdsRemoved() => PlayerPrefs.GetInt(KEY_ADS_REMOVED, 0) == 1;

        #endregion

        #region Characters

        public void SetSelectedCharacter(string characterId)
        {
            PlayerPrefs.SetString(KEY_SELECTED_CHARACTER, characterId);
            PlayerPrefs.Save();
        }

        public string GetSelectedCharacter() =>
            PlayerPrefs.GetString(KEY_SELECTED_CHARACTER, "chaiwala");

        public void UnlockCharacter(string characterId)
        {
            string unlocked = PlayerPrefs.GetString(KEY_UNLOCKED_CHARS, "chaiwala");
            if (!unlocked.Contains(characterId))
            {
                unlocked += "," + characterId;
                PlayerPrefs.SetString(KEY_UNLOCKED_CHARS, unlocked);
                PlayerPrefs.Save();
            }
        }

        public bool IsCharacterUnlocked(string characterId)
        {
            string unlocked = PlayerPrefs.GetString(KEY_UNLOCKED_CHARS, "chaiwala");
            return unlocked.Contains(characterId);
        }

        public string[] GetUnlockedCharacters()
        {
            string unlocked = PlayerPrefs.GetString(KEY_UNLOCKED_CHARS, "chaiwala");
            return unlocked.Split(',');
        }

        #endregion

        #region Daily Rewards

        public void SetDailyRewardDay(int day)
        {
            PlayerPrefs.SetInt(KEY_DAILY_REWARD_DAY, day);
            PlayerPrefs.Save();
        }

        public int GetDailyRewardDay() => PlayerPrefs.GetInt(KEY_DAILY_REWARD_DAY, 0);

        public void SetDailyRewardTimestamp(string timestamp)
        {
            PlayerPrefs.SetString(KEY_DAILY_REWARD_TIMESTAMP, timestamp);
            PlayerPrefs.Save();
        }

        public string GetDailyRewardTimestamp() =>
            PlayerPrefs.GetString(KEY_DAILY_REWARD_TIMESTAMP, "");

        #endregion

        #region Stats

        public void IncrementTotalGames()
        {
            int total = PlayerPrefs.GetInt(KEY_TOTAL_GAMES, 0) + 1;
            PlayerPrefs.SetInt(KEY_TOTAL_GAMES, total);
            PlayerPrefs.Save();
        }

        public int GetTotalGames() => PlayerPrefs.GetInt(KEY_TOTAL_GAMES, 0);

        #endregion

        /// <summary>
        /// Delete ALL saved data. Use with caution!
        /// </summary>
        public void DeleteAllData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("[SaveManager] All data deleted!");
        }
    }
}
