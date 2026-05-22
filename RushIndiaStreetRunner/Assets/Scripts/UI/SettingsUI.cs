using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RushIndia.UI
{
    /// <summary>
    /// Settings screen - sound/music toggles, social links, support.
    /// Clean mobile-friendly layout with large toggle buttons.
    /// </summary>
    public class SettingsUI : MonoBehaviour
    {
        [Header("Toggle Buttons")]
        [SerializeField] private Toggle soundToggle;
        [SerializeField] private Toggle musicToggle;

        [Header("Other Buttons")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button restorePurchasesButton;
        [SerializeField] private Button privacyPolicyButton;
        [SerializeField] private Button rateUsButton;
        [SerializeField] private Button resetDataButton;

        [Header("Display")]
        [SerializeField] private TextMeshProUGUI versionText;

        // TODO: Replace with your actual URLs
        private const string PRIVACY_POLICY_URL = "https://yourwebsite.com/privacy";
        private const string PLAY_STORE_URL = "https://play.google.com/store/apps/details?id=com.rushindiastreetrunner.game";

        private void Start()
        {
            LoadSettings();
            SetupListeners();

            if (versionText != null)
                versionText.text = $"v{Application.version}";
        }

        /// <summary>
        /// Load current settings state into UI toggles.
        /// </summary>
        private void LoadSettings()
        {
            bool soundOn = Core.AudioManager.Instance?.IsSoundEnabled() ?? true;
            bool musicOn = Core.AudioManager.Instance?.IsMusicEnabled() ?? true;

            if (soundToggle != null) soundToggle.isOn = soundOn;
            if (musicToggle != null) musicToggle.isOn = musicOn;
        }

        private void SetupListeners()
        {
            if (soundToggle != null)
                soundToggle.onValueChanged.AddListener(OnSoundToggled);

            if (musicToggle != null)
                musicToggle.onValueChanged.AddListener(OnMusicToggled);

            if (backButton != null)
                backButton.onClick.AddListener(OnBackClicked);

            if (restorePurchasesButton != null)
                restorePurchasesButton.onClick.AddListener(OnRestorePurchases);

            if (privacyPolicyButton != null)
                privacyPolicyButton.onClick.AddListener(OnPrivacyPolicy);

            if (rateUsButton != null)
                rateUsButton.onClick.AddListener(OnRateUs);

            if (resetDataButton != null)
                resetDataButton.onClick.AddListener(OnResetData);
        }

        private void OnSoundToggled(bool isOn)
        {
            Core.AudioManager.Instance?.SetSoundEnabled(isOn);
            if (isOn) Core.AudioManager.Instance?.PlayButtonClick();
        }

        private void OnMusicToggled(bool isOn)
        {
            Core.AudioManager.Instance?.SetMusicEnabled(isOn);
        }

        private void OnBackClicked()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Core.GameManager.Instance?.LoadScene("MainMenu");
        }

        private void OnRestorePurchases()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            Gameplay.IAPManager.Instance?.RestorePurchases();
        }

        private void OnPrivacyPolicy()
        {
            Application.OpenURL(PRIVACY_POLICY_URL);
        }

        private void OnRateUs()
        {
            Application.OpenURL(PLAY_STORE_URL);
        }

        /// <summary>
        /// Reset all player data. Show confirmation first in real implementation.
        /// </summary>
        private void OnResetData()
        {
            Core.AudioManager.Instance?.PlayButtonClick();
            // TODO: Show confirmation dialog before deleting
            Debug.LogWarning("[Settings] Data reset requested - implement confirmation dialog!");
            // Core.SaveManager.Instance?.DeleteAllData();
        }
    }
}
