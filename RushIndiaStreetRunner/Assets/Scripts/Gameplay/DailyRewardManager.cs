using UnityEngine;
using System;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Manages 7-day daily reward cycle.
    /// Players get increasing rewards for consecutive daily logins.
    /// Resets after day 7 or if a day is missed.
    /// </summary>
    public class DailyRewardManager : MonoBehaviour
    {
        public static DailyRewardManager Instance { get; private set; }

        [System.Serializable]
        public class DailyReward
        {
            public int day;
            public int coinReward;
            public int gemReward;
            public string specialReward; // Character unlock, etc.
        }

        [Header("Reward Schedule (7 days)")]
        [SerializeField] private DailyReward[] rewardSchedule = new DailyReward[]
        {
            new DailyReward { day = 1, coinReward = 100, gemReward = 0, specialReward = "" },
            new DailyReward { day = 2, coinReward = 150, gemReward = 1, specialReward = "" },
            new DailyReward { day = 3, coinReward = 200, gemReward = 2, specialReward = "" },
            new DailyReward { day = 4, coinReward = 300, gemReward = 3, specialReward = "" },
            new DailyReward { day = 5, coinReward = 400, gemReward = 5, specialReward = "" },
            new DailyReward { day = 6, coinReward = 500, gemReward = 5, specialReward = "" },
            new DailyReward { day = 7, coinReward = 1000, gemReward = 10, specialReward = "festival_skin" }
        };

        private int currentDay;
        private bool canClaimToday;

        // Events
        public System.Action<DailyReward> OnRewardClaimed;
        public System.Action<int, bool> OnDailyRewardStatusChecked; // day, canClaim

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
            CheckDailyRewardStatus();
        }

        /// <summary>
        /// Check if the player can claim today's reward.
        /// </summary>
        public void CheckDailyRewardStatus()
        {
            currentDay = Core.SaveManager.Instance?.GetDailyRewardDay() ?? 0;
            string lastClaimStr = Core.SaveManager.Instance?.GetDailyRewardTimestamp() ?? "";

            if (string.IsNullOrEmpty(lastClaimStr))
            {
                // First time player - can claim day 1
                canClaimToday = true;
                currentDay = 0;
            }
            else
            {
                DateTime lastClaim = DateTime.Parse(lastClaimStr);
                TimeSpan timeSinceClaim = DateTime.Now - lastClaim;

                if (timeSinceClaim.TotalHours >= 24 && timeSinceClaim.TotalHours < 48)
                {
                    // Exactly next day - continue streak
                    canClaimToday = true;
                }
                else if (timeSinceClaim.TotalHours >= 48)
                {
                    // Missed a day - reset streak
                    currentDay = 0;
                    canClaimToday = true;
                }
                else
                {
                    // Already claimed today
                    canClaimToday = false;
                }
            }

            OnDailyRewardStatusChecked?.Invoke(currentDay, canClaimToday);
        }

        /// <summary>
        /// Claim today's reward. Returns the reward data.
        /// </summary>
        public DailyReward ClaimReward()
        {
            if (!canClaimToday) return null;

            // Advance day (wrap after 7)
            currentDay = (currentDay % 7);
            DailyReward reward = rewardSchedule[currentDay];

            // Grant rewards
            Core.CoinManager.Instance?.AddCoins(reward.coinReward);
            Core.CoinManager.Instance?.AddGems(reward.gemReward);

            // Handle special rewards
            if (!string.IsNullOrEmpty(reward.specialReward))
            {
                Core.SaveManager.Instance?.UnlockCharacter(reward.specialReward);
            }

            // Save progress
            currentDay++;
            Core.SaveManager.Instance?.SetDailyRewardDay(currentDay);
            Core.SaveManager.Instance?.SetDailyRewardTimestamp(DateTime.Now.ToString());

            canClaimToday = false;
            OnRewardClaimed?.Invoke(reward);

            Debug.Log($"[DailyReward] Claimed Day {reward.day}: {reward.coinReward} coins, {reward.gemReward} gems");
            return reward;
        }

        public bool CanClaimToday() => canClaimToday;
        public int GetCurrentDay() => currentDay;
        public DailyReward[] GetRewardSchedule() => rewardSchedule;
    }
}
