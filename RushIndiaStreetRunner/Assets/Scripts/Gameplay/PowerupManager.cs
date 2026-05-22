using UnityEngine;
using System.Collections;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Manages powerup activation, duration, and effects.
    /// Powerups: Coin Magnet, Shield, Jetpack, Double Coins, Speed Boost.
    /// </summary>
    public class PowerupManager : MonoBehaviour
    {
        public static PowerupManager Instance { get; private set; }

        [Header("Powerup Durations (seconds)")]
        [SerializeField] private float magnetDuration = 8f;
        [SerializeField] private float shieldDuration = 10f;
        [SerializeField] private float jetpackDuration = 5f;
        [SerializeField] private float doubleCoinsDuration = 10f;
        [SerializeField] private float speedBoostDuration = 5f;

        [Header("Spawn Settings")]
        [SerializeField] private float powerupSpawnChance = 0.1f;
        [SerializeField] private GameObject[] powerupPrefabs;

        // Active powerup coroutines (so we can stop them)
        private Coroutine magnetCoroutine;
        private Coroutine shieldCoroutine;
        private Coroutine jetpackCoroutine;
        private Coroutine doubleCoinsCoroutine;
        private Coroutine speedBoostCoroutine;

        // Player reference
        private Core.PlayerController player;

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
            player = FindObjectOfType<Core.PlayerController>();
        }

        /// <summary>
        /// Activate a powerup by type name.
        /// Called when player collects a powerup item.
        /// </summary>
        public void ActivatePowerup(string powerupType)
        {
            Core.AudioManager.Instance?.PlayPowerup();

            switch (powerupType)
            {
                case "Magnet":
                    ActivateMagnet();
                    break;
                case "Shield":
                    ActivateShield();
                    break;
                case "Jetpack":
                    ActivateJetpack();
                    break;
                case "DoubleCoins":
                    ActivateDoubleCoins();
                    break;
                case "SpeedBoost":
                    ActivateSpeedBoost();
                    break;
                default:
                    Debug.LogWarning($"[PowerupManager] Unknown powerup: {powerupType}");
                    break;
            }
        }

        #region Magnet

        private void ActivateMagnet()
        {
            if (magnetCoroutine != null) StopCoroutine(magnetCoroutine);
            magnetCoroutine = StartCoroutine(MagnetRoutine());
        }

        private IEnumerator MagnetRoutine()
        {
            player?.ActivateMagnet(true);
            Core.UIManager.Instance?.ShowPowerupIndicator("Magnet", true);

            yield return new WaitForSeconds(magnetDuration);

            player?.ActivateMagnet(false);
            Core.UIManager.Instance?.ShowPowerupIndicator("Magnet", false);
            magnetCoroutine = null;
        }

        #endregion

        #region Shield

        private void ActivateShield()
        {
            if (shieldCoroutine != null) StopCoroutine(shieldCoroutine);
            shieldCoroutine = StartCoroutine(ShieldRoutine());
        }

        private IEnumerator ShieldRoutine()
        {
            player?.ActivateShield();
            Core.UIManager.Instance?.ShowPowerupIndicator("Shield", true);

            yield return new WaitForSeconds(shieldDuration);

            Core.UIManager.Instance?.ShowPowerupIndicator("Shield", false);
            shieldCoroutine = null;
        }

        #endregion

        #region Jetpack

        private void ActivateJetpack()
        {
            if (jetpackCoroutine != null) StopCoroutine(jetpackCoroutine);
            jetpackCoroutine = StartCoroutine(JetpackRoutine());
        }

        private IEnumerator JetpackRoutine()
        {
            // TODO: Lift player above obstacles, make invincible
            Core.UIManager.Instance?.ShowPowerupIndicator("SpeedBoost", true);
            Debug.Log("[PowerupManager] Jetpack activated!");

            yield return new WaitForSeconds(jetpackDuration);

            Core.UIManager.Instance?.ShowPowerupIndicator("SpeedBoost", false);
            jetpackCoroutine = null;
        }

        #endregion

        #region Double Coins

        private void ActivateDoubleCoins()
        {
            if (doubleCoinsCoroutine != null) StopCoroutine(doubleCoinsCoroutine);
            doubleCoinsCoroutine = StartCoroutine(DoubleCoinsRoutine());
        }

        private IEnumerator DoubleCoinsRoutine()
        {
            Core.CoinManager.Instance?.SetDoubleCoins(true);
            Core.UIManager.Instance?.ShowPowerupIndicator("DoubleCoins", true);
            Core.GameManager.Instance?.SetScoreMultiplier(2f);

            yield return new WaitForSeconds(doubleCoinsDuration);

            Core.CoinManager.Instance?.SetDoubleCoins(false);
            Core.UIManager.Instance?.ShowPowerupIndicator("DoubleCoins", false);
            Core.GameManager.Instance?.SetScoreMultiplier(1f);
            doubleCoinsCoroutine = null;
        }

        #endregion

        #region Speed Boost

        private void ActivateSpeedBoost()
        {
            if (speedBoostCoroutine != null) StopCoroutine(speedBoostCoroutine);
            speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine());
        }

        private IEnumerator SpeedBoostRoutine()
        {
            // TODO: Temporarily increase speed + invincibility
            Core.UIManager.Instance?.ShowPowerupIndicator("SpeedBoost", true);
            Debug.Log("[PowerupManager] Speed Boost activated!");

            yield return new WaitForSeconds(speedBoostDuration);

            Core.UIManager.Instance?.ShowPowerupIndicator("SpeedBoost", false);
            speedBoostCoroutine = null;
        }

        #endregion

        /// <summary>
        /// Deactivate all active powerups (on death/restart).
        /// </summary>
        public void DeactivateAll()
        {
            StopAllCoroutines();
            magnetCoroutine = null;
            shieldCoroutine = null;
            jetpackCoroutine = null;
            doubleCoinsCoroutine = null;
            speedBoostCoroutine = null;

            player?.ActivateMagnet(false);
            Core.CoinManager.Instance?.SetDoubleCoins(false);
            Core.GameManager.Instance?.SetScoreMultiplier(1f);
        }
    }
}
