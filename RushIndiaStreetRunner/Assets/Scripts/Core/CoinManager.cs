using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Manages coin and gem economy: collecting, spending, saving.
    /// Tracks lifetime earnings for achievements/missions.
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance { get; private set; }

        [Header("Coin Values")]
        [SerializeField] private int coinValue = 1;
        [SerializeField] private int gemValue = 5;

        [Header("Current Session")]
        [SerializeField] private int sessionCoins;
        [SerializeField] private int sessionGems;

        // Persistent totals (loaded from save)
        private int totalCoins;
        private int totalGems;

        // Double coins powerup
        private bool doubleCoinsActive;

        // Events
        public System.Action<int> OnCoinsChanged;
        public System.Action<int> OnGemsChanged;
        public System.Action<int> OnSessionCoinsChanged;

        public int TotalCoins => totalCoins;
        public int TotalGems => totalGems;
        public int SessionCoins => sessionCoins;

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
            LoadCurrency();
        }


        /// <summary>
        /// Load saved currency from persistent storage.
        /// </summary>
        private void LoadCurrency()
        {
            if (SaveManager.Instance != null)
            {
                totalCoins = SaveManager.Instance.GetCoins();
                totalGems = SaveManager.Instance.GetGems();
            }
        }

        /// <summary>
        /// Reset session coins for a new run.
        /// </summary>
        public void ResetSession()
        {
            sessionCoins = 0;
            sessionGems = 0;
        }

        /// <summary>
        /// Collect a coin during gameplay.
        /// </summary>
        public void CollectCoin()
        {
            int amount = doubleCoinsActive ? coinValue * 2 : coinValue;
            sessionCoins += amount;
            totalCoins += amount;

            OnSessionCoinsChanged?.Invoke(sessionCoins);
            OnCoinsChanged?.Invoke(totalCoins);

            // Add score bonus
            GameManager.Instance?.AddScore(amount * 10f);
        }

        /// <summary>
        /// Collect a gem during gameplay.
        /// </summary>
        public void CollectGem()
        {
            int amount = doubleCoinsActive ? gemValue * 2 : gemValue;
            sessionGems += amount;
            totalGems += amount;

            OnGemsChanged?.Invoke(totalGems);
            GameManager.Instance?.AddScore(amount * 50f);
        }


        /// <summary>
        /// Spend coins (shop purchases).
        /// Returns true if purchase successful.
        /// </summary>
        public bool SpendCoins(int amount)
        {
            if (totalCoins < amount) return false;

            totalCoins -= amount;
            OnCoinsChanged?.Invoke(totalCoins);
            SaveCurrency();
            return true;
        }

        /// <summary>
        /// Spend gems (premium purchases).
        /// </summary>
        public bool SpendGems(int amount)
        {
            if (totalGems < amount) return false;

            totalGems -= amount;
            OnGemsChanged?.Invoke(totalGems);
            SaveCurrency();
            return true;
        }

        /// <summary>
        /// Add coins (IAP purchase, daily reward, ad reward).
        /// </summary>
        public void AddCoins(int amount)
        {
            totalCoins += amount;
            OnCoinsChanged?.Invoke(totalCoins);
            SaveCurrency();
        }

        /// <summary>
        /// Add gems (IAP purchase, daily reward).
        /// </summary>
        public void AddGems(int amount)
        {
            totalGems += amount;
            OnGemsChanged?.Invoke(totalGems);
            SaveCurrency();
        }

        /// <summary>
        /// Activate double coins powerup.
        /// </summary>
        public void SetDoubleCoins(bool active)
        {
            doubleCoinsActive = active;
        }

        /// <summary>
        /// Save session earnings to persistent storage.
        /// Call at end of each run.
        /// </summary>
        public void SaveSessionEarnings()
        {
            SaveCurrency();
        }

        private void SaveCurrency()
        {
            SaveManager.Instance?.SaveCoins(totalCoins);
            SaveManager.Instance?.SaveGems(totalGems);
        }
    }
}
