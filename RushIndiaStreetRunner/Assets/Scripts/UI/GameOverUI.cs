using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RushIndia.UI
{
    /// <summary>
    /// Game Over screen UI controller.
    /// Shows score, coins earned, options to retry/watch ad/go to menu.
    /// </summary>
    public class GameOverUI : MonoBehaviour
    {
        [Header("Score Display")]
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private TextMeshProUGUI coinsEarnedText;
        [SerializeField] private GameObject newHighScoreLabel;

        [Header("Buttons")]
        [SerializeField] private Button retryButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button watchAdButton;     // Watch ad for extra coins
        [SerializeField] private Button shareButton;       // Share score (viral hook)

        [Header("Ad Reward")]
        [SerializeField] private int adRewardCoins = 50;

        private bool adWatched;

        private void OnEnable()
        {
            SetupUI();
            SetupButtons();
        }

        /// <summary>
        /// Populate UI with game results.
        /// </summary>
        private void SetupUI()
        {
            if (Core.GameManager.Instance == null) return;

            int score = Mathf.FloorToInt(Core.GameManager.Instance.CurrentScore);
            int highScore = Core.SaveManager.Instance?.GetHighScore() ?? 0;
            int sessionCoins = Core.CoinManager.Instance?.SessionCoins ?? 0;

            if (finalScoreText != null)
                finalScoreText.text = score.ToString("N0");

            if (highScoreText != null)
                highScoreText.text = $"Best: {highScore:N0}";

            if (coinsEarnedText != null)
                coinsEarnedText.text = $"+{sessionCoins}";

            // Show "NEW HIGH SCORE" if applicable
            if (newHighScoreLabel != null)
                newHighScoreLabel.SetActive(score >= highScore && score > 0);

            // Submit to leaderboard
            Gameplay.LeaderboardManager.Instance?.SubmitScore(score,
                Core.GameManager.Instance.SelectedCityId);

            // Report to missions
            Gameplay.MissionManager.Instance?.ReportProgress(
                Gameplay.MissionManager.MissionType.ScorePoints, score);

            // Reset ad button state
            adWatched = false;
            UpdateAdButton();
        }

        private void SetupButtons()
        {
            if (retryButton != null)
                retryButton.onClick.AddListener(OnRetryClicked);

            if (mainMenuButton != null)
                mainMenuButton.onClick.AddListener(OnMainMenuClicked);

            if (watchAdButton != null)
                watchAdButton.onClick.AddListener(OnWatchAdClicked);

            if (shareButton != null)
                shareButton.onClick.AddListener(OnShareClicked);
        }

        private void OnRetryClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.CoinManager.Instance?.SaveSessionEarnings();
            Core.GameManager.Instance?.RestartGame();
        }

        private void OnMainMenuClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.CoinManager.Instance?.SaveSessionEarnings();
            Core.GameManager.Instance?.GoToMainMenu();
        }

        /// <summary>
        /// Watch rewarded ad for bonus coins.
        /// </summary>
        private void OnWatchAdClicked()
        {
            if (adWatched) return;

            Core.AudioManager.Instance?.PlayButtonClick();

            if (Core.AdManager.Instance != null && Core.AdManager.Instance.IsRewardedAdReady())
            {
                Core.AdManager.Instance.OnRewardedAdCompleted += OnAdRewardGranted;
                Core.AdManager.Instance.ShowRewardedAd();
            }
        }

        private void OnAdRewardGranted()
        {
            Core.AdManager.Instance.OnRewardedAdCompleted -= OnAdRewardGranted;

            Core.CoinManager.Instance?.AddCoins(adRewardCoins);
            adWatched = true;
            UpdateAdButton();

            if (coinsEarnedText != null)
            {
                int total = (Core.CoinManager.Instance?.SessionCoins ?? 0) + adRewardCoins;
                coinsEarnedText.text = $"+{total}";
            }
        }

        private void UpdateAdButton()
        {
            if (watchAdButton != null)
                watchAdButton.interactable = !adWatched;
        }

        /// <summary>
        /// Share score - opens native share sheet.
        /// Great for viral Reels/Shorts moments!
        /// </summary>
        private void OnShareClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();

            int score = Mathf.FloorToInt(Core.GameManager.Instance?.CurrentScore ?? 0);
            string message = $"I scored {score:N0} points in Rush India: Street Runner! Can you beat me? #RushIndia #EndlessRunner";

            // TODO: Implement native share using NativeShare plugin
            // new NativeShare().SetText(message).Share();

            Debug.Log($"[Share] {message}");
        }
    }
}
