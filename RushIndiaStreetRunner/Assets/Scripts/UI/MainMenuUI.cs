using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RushIndia.UI
{
    /// <summary>
    /// Main Menu screen controller.
    /// Hub for navigating to Play, Shop, Rewards, Settings, Leaderboard.
    /// Shows current coins/gems, daily reward notification.
    /// </summary>
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Currency Display")]
        [SerializeField] private TextMeshProUGUI coinCountText;
        [SerializeField] private TextMeshProUGUI gemCountText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        [Header("Navigation Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button rewardsButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button leaderboardButton;

        [Header("Daily Reward")]
        [SerializeField] private GameObject dailyRewardNotification; // Red dot badge

        [Header("Character Preview")]
        [SerializeField] private TextMeshProUGUI characterNameText;
        // TODO: Add 3D character model preview

        private void Start()
        {
            SetupButtons();
            RefreshUI();
            CheckDailyReward();

            // Play menu music
            Core.AudioManager.Instance?.PlayMenuMusic();

            // Show banner ad on menu
            Core.AdManager.Instance?.ShowBanner();
        }

        private void SetupButtons()
        {
            if (playButton != null)
                playButton.onClick.AddListener(OnPlayClicked);
            if (shopButton != null)
                shopButton.onClick.AddListener(OnShopClicked);
            if (rewardsButton != null)
                rewardsButton.onClick.AddListener(OnRewardsClicked);
            if (settingsButton != null)
                settingsButton.onClick.AddListener(OnSettingsClicked);
            if (leaderboardButton != null)
                leaderboardButton.onClick.AddListener(OnLeaderboardClicked);
        }

        /// <summary>
        /// Refresh currency and score displays.
        /// </summary>
        private void RefreshUI()
        {
            if (coinCountText != null && Core.CoinManager.Instance != null)
                coinCountText.text = Core.CoinManager.Instance.TotalCoins.ToString("N0");

            if (gemCountText != null && Core.CoinManager.Instance != null)
                gemCountText.text = Core.CoinManager.Instance.TotalGems.ToString();

            if (highScoreText != null && Core.SaveManager.Instance != null)
                highScoreText.text = $"Best: {Core.SaveManager.Instance.GetHighScore():N0}";

            // Show current character name
            if (characterNameText != null)
            {
                string charId = Core.SaveManager.Instance?.GetSelectedCharacter() ?? "Chaiwala";
                characterNameText.text = charId;
            }
        }

        /// <summary>
        /// Check if daily reward is available and show notification.
        /// </summary>
        private void CheckDailyReward()
        {
            if (dailyRewardNotification == null) return;

            bool canClaim = Gameplay.DailyRewardManager.Instance?.CanClaimToday() ?? false;
            dailyRewardNotification.SetActive(canClaim);
        }

        #region Button Handlers

        private void OnPlayClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.AdManager.Instance?.HideBanner();
            Core.GameManager.Instance?.LoadScene("CitySelection");
        }

        private void OnShopClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.GameManager.Instance?.LoadScene("Shop");
        }

        private void OnRewardsClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.GameManager.Instance?.LoadScene("Rewards");
        }

        private void OnSettingsClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.GameManager.Instance?.LoadScene("Settings");
        }

        private void OnLeaderboardClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            // TODO: Open leaderboard panel/scene
            Debug.Log("[MainMenu] Leaderboard clicked");
        }

        #endregion
    }
}
