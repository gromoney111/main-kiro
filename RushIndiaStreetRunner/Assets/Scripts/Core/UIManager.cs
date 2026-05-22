using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RushIndia.Core
{
    /// <summary>
    /// Manages in-game HUD during gameplay.
    /// Updates score display, coin count, powerup indicators.
    /// Handles pause menu overlay.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("HUD Elements")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI gemText;
        [SerializeField] private TextMeshProUGUI distanceText;

        [Header("Powerup Indicators")]
        [SerializeField] private GameObject shieldIndicator;
        [SerializeField] private GameObject magnetIndicator;
        [SerializeField] private GameObject doubleCoinsIndicator;
        [SerializeField] private GameObject speedBoostIndicator;

        [Header("Panels")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject hudPanel;

        [Header("Buttons")]
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;

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
            SetupButtons();
            HidePausePanel();
            HideAllPowerupIndicators();
        }

        private void OnEnable()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnScoreUpdated += UpdateScore;
                GameManager.Instance.OnGamePaused += ShowPausePanel;
                GameManager.Instance.OnGameResumed += HidePausePanel;
            }

            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.OnSessionCoinsChanged += UpdateCoinDisplay;
                CoinManager.Instance.OnGemsChanged += UpdateGemDisplay;
            }
        }

        private void OnDisable()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnScoreUpdated -= UpdateScore;
                GameManager.Instance.OnGamePaused -= ShowPausePanel;
                GameManager.Instance.OnGameResumed -= HidePausePanel;
            }

            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.OnSessionCoinsChanged -= UpdateCoinDisplay;
                CoinManager.Instance.OnGemsChanged -= UpdateGemDisplay;
            }
        }


        private void SetupButtons()
        {
            if (pauseButton != null)
                pauseButton.onClick.AddListener(OnPauseClicked);
            if (resumeButton != null)
                resumeButton.onClick.AddListener(OnResumeClicked);
            if (quitButton != null)
                quitButton.onClick.AddListener(OnQuitClicked);
        }

        #region Score & Currency Display

        private void UpdateScore(float score)
        {
            if (scoreText != null)
                scoreText.text = Mathf.FloorToInt(score).ToString("N0");
        }

        private void UpdateCoinDisplay(int coins)
        {
            if (coinText != null)
                coinText.text = coins.ToString();
        }

        private void UpdateGemDisplay(int gems)
        {
            if (gemText != null)
                gemText.text = gems.ToString();
        }

        #endregion

        #region Powerup Indicators

        public void ShowPowerupIndicator(string powerupType, bool show)
        {
            switch (powerupType)
            {
                case "Shield":
                    if (shieldIndicator != null) shieldIndicator.SetActive(show);
                    break;
                case "Magnet":
                    if (magnetIndicator != null) magnetIndicator.SetActive(show);
                    break;
                case "DoubleCoins":
                    if (doubleCoinsIndicator != null) doubleCoinsIndicator.SetActive(show);
                    break;
                case "SpeedBoost":
                    if (speedBoostIndicator != null) speedBoostIndicator.SetActive(show);
                    break;
            }
        }

        private void HideAllPowerupIndicators()
        {
            if (shieldIndicator != null) shieldIndicator.SetActive(false);
            if (magnetIndicator != null) magnetIndicator.SetActive(false);
            if (doubleCoinsIndicator != null) doubleCoinsIndicator.SetActive(false);
            if (speedBoostIndicator != null) speedBoostIndicator.SetActive(false);
        }

        #endregion

        #region Pause Menu

        private void ShowPausePanel()
        {
            if (pausePanel != null) pausePanel.SetActive(true);
            if (hudPanel != null) hudPanel.SetActive(false);
        }

        private void HidePausePanel()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (hudPanel != null) hudPanel.SetActive(true);
        }

        private void OnPauseClicked()
        {
            AudioManager.Instance?.PlayButtonClick();
            GameManager.Instance?.PauseGame();
        }

        private void OnResumeClicked()
        {
            AudioManager.Instance?.PlayButtonClick();
            GameManager.Instance?.ResumeGame();
        }

        private void OnQuitClicked()
        {
            AudioManager.Instance?.PlayButtonClick();
            GameManager.Instance?.GoToMainMenu();
        }

        #endregion
    }
}
