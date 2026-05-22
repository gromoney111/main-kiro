using UnityEngine;
using UnityEngine.SceneManagement;

namespace RushIndia.Core
{
    /// <summary>
    /// Central game manager - controls game state, score, difficulty scaling.
    /// Singleton pattern ensures only one instance exists across scenes.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Game State")]
        [SerializeField] private GameState currentState = GameState.Menu;

        [Header("Scoring")]
        [SerializeField] private float scoreMultiplier = 1f;
        [SerializeField] private float distanceScoreRate = 10f; // Points per second of running

        [Header("Difficulty Scaling")]
        [SerializeField] private float baseSpeed = 8f;
        [SerializeField] private float maxSpeed = 25f;
        [SerializeField] private float speedIncreaseRate = 0.05f; // Speed increase per second
        [SerializeField] private float spawnRateIncreaseRate = 0.02f;

        [Header("Game Rules")]
        [SerializeField] private int interstitialAdInterval = 3; // Show ad every N games

        // Runtime state
        private float currentScore;
        private float currentSpeed;
        private float gameTime;
        private int gamesPlayedSinceAd;
        private string selectedCityId;

        // Public accessors
        public GameState CurrentState => currentState;
        public float CurrentScore => currentScore;
        public float CurrentSpeed => currentSpeed;
        public float GameTime => gameTime;
        public float DifficultyFactor => Mathf.Clamp01(gameTime / 120f); // 0-1 over 2 minutes
        public string SelectedCityId => selectedCityId;

        // Events for decoupled communication
        public System.Action<GameState> OnGameStateChanged;
        public System.Action<float> OnScoreUpdated;
        public System.Action OnGameOver;
        public System.Action OnGamePaused;
        public System.Action OnGameResumed;

        private void Awake()
        {
            // Singleton setup - persist across scenes
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Target 60fps on mobile
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }

        /// <summary>
        /// Call this when player selects a city from CitySelection screen.
        /// </summary>
        public void SetSelectedCity(string cityId)
        {
            selectedCityId = cityId;
        }

        /// <summary>
        /// Starts a new game run. Call from Gameplay scene initialization.
        /// </summary>
        public void StartGame()
        {
            currentScore = 0f;
            currentSpeed = baseSpeed;
            gameTime = 0f;
            scoreMultiplier = 1f;

            SetState(GameState.Playing);
        }

        /// <summary>
        /// Called every frame during gameplay to update score and difficulty.
        /// </summary>
        private void Update()
        {
            if (currentState != GameState.Playing) return;

            // Increase game time
            gameTime += Time.deltaTime;

            // Gradually increase speed (difficulty)
            currentSpeed = Mathf.Min(
                baseSpeed + (speedIncreaseRate * gameTime),
                maxSpeed
            );

            // Accumulate score based on distance
            currentScore += distanceScoreRate * scoreMultiplier * Time.deltaTime;
            OnScoreUpdated?.Invoke(currentScore);
        }

        /// <summary>
        /// Add bonus score (coins, gems, combos).
        /// </summary>
        public void AddScore(float amount)
        {
            currentScore += amount * scoreMultiplier;
            OnScoreUpdated?.Invoke(currentScore);
        }

        /// <summary>
        /// Set score multiplier (e.g., double coins powerup).
        /// </summary>
        public void SetScoreMultiplier(float multiplier)
        {
            scoreMultiplier = multiplier;
        }

        /// <summary>
        /// Trigger game over - save score, show ads if needed.
        /// </summary>
        public void TriggerGameOver()
        {
            SetState(GameState.GameOver);

            // Save high score
            int finalScore = Mathf.FloorToInt(currentScore);
            SaveManager.Instance?.SaveHighScore(finalScore);

            // Track games for interstitial ad timing
            gamesPlayedSinceAd++;

            // Show interstitial ad every N games
            if (gamesPlayedSinceAd >= interstitialAdInterval)
            {
                gamesPlayedSinceAd = 0;
                AdManager.Instance?.ShowInterstitial();
            }

            OnGameOver?.Invoke();
        }

        /// <summary>
        /// Pause the game (time scale = 0).
        /// </summary>
        public void PauseGame()
        {
            if (currentState != GameState.Playing) return;

            Time.timeScale = 0f;
            SetState(GameState.Paused);
            OnGamePaused?.Invoke();
        }

        /// <summary>
        /// Resume gameplay.
        /// </summary>
        public void ResumeGame()
        {
            if (currentState != GameState.Paused) return;

            Time.timeScale = 1f;
            SetState(GameState.Playing);
            OnGameResumed?.Invoke();
        }

        /// <summary>
        /// Restart the current run.
        /// </summary>
        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Gameplay");
        }

        /// <summary>
        /// Return to main menu.
        /// </summary>
        public void GoToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// Load a specific scene by name.
        /// </summary>
        public void LoadScene(string sceneName)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }

        private void SetState(GameState newState)
        {
            currentState = newState;
            OnGameStateChanged?.Invoke(newState);
        }
    }

    /// <summary>
    /// All possible game states for clean state management.
    /// </summary>
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver,
        Loading
    }
}
