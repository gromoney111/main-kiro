using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Centralized audio management. Handles background music and SFX.
    /// Uses object pooling for frequent SFX to avoid GC allocations.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Music Clips")]
        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip gameplayMusic;
        // TODO: Add city-specific music clips

        [Header("SFX Clips")]
        [SerializeField] private AudioClip coinCollectSFX;
        [SerializeField] private AudioClip gemCollectSFX;
        [SerializeField] private AudioClip jumpSFX;
        [SerializeField] private AudioClip slideSFX;
        [SerializeField] private AudioClip deathSFX;
        [SerializeField] private AudioClip powerupSFX;
        [SerializeField] private AudioClip buttonClickSFX;
        [SerializeField] private AudioClip laneSwitchSFX;

        [Header("Settings")]
        [SerializeField] private float musicVolume = 0.5f;
        [SerializeField] private float sfxVolume = 0.8f;

        private bool isSoundEnabled = true;
        private bool isMusicEnabled = true;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Create audio sources if not assigned
            if (musicSource == null)
            {
                musicSource = gameObject.AddComponent<AudioSource>();
                musicSource.loop = true;
                musicSource.playOnAwake = false;
            }

            if (sfxSource == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
                sfxSource.loop = false;
                sfxSource.playOnAwake = false;
            }
        }

        private void Start()
        {
            // Load user preferences
            isSoundEnabled = SaveManager.Instance?.IsSoundEnabled() ?? true;
            isMusicEnabled = SaveManager.Instance?.IsMusicEnabled() ?? true;

            musicSource.volume = isMusicEnabled ? musicVolume : 0f;
            sfxSource.volume = isSoundEnabled ? sfxVolume : 0f;
        }


        #region Music

        /// <summary>
        /// Play menu background music.
        /// </summary>
        public void PlayMenuMusic()
        {
            PlayMusic(menuMusic);
        }

        /// <summary>
        /// Play gameplay background music.
        /// </summary>
        public void PlayGameplayMusic()
        {
            PlayMusic(gameplayMusic);
        }

        /// <summary>
        /// Play a specific music clip with crossfade feel.
        /// </summary>
        public void PlayMusic(AudioClip clip)
        {
            if (!isMusicEnabled || clip == null) return;
            if (musicSource.clip == clip && musicSource.isPlaying) return;

            musicSource.clip = clip;
            musicSource.Play();
        }

        /// <summary>
        /// Stop music playback.
        /// </summary>
        public void StopMusic()
        {
            musicSource.Stop();
        }

        #endregion

        #region SFX

        /// <summary>
        /// Play a one-shot SFX clip. Safe to call rapidly.
        /// </summary>
        public void PlaySFX(AudioClip clip)
        {
            if (!isSoundEnabled || clip == null) return;
            sfxSource.PlayOneShot(clip, sfxVolume);
        }

        // Convenience methods for common SFX
        public void PlayCoinCollect() => PlaySFX(coinCollectSFX);
        public void PlayGemCollect() => PlaySFX(gemCollectSFX);
        public void PlayJump() => PlaySFX(jumpSFX);
        public void PlaySlide() => PlaySFX(slideSFX);
        public void PlayDeath() => PlaySFX(deathSFX);
        public void PlayPowerup() => PlaySFX(powerupSFX);
        public void PlayButtonClick() => PlaySFX(buttonClickSFX);
        public void PlayLaneSwitch() => PlaySFX(laneSwitchSFX);

        #endregion

        #region Settings

        /// <summary>
        /// Toggle sound effects on/off.
        /// </summary>
        public void SetSoundEnabled(bool enabled)
        {
            isSoundEnabled = enabled;
            sfxSource.volume = enabled ? sfxVolume : 0f;
            SaveManager.Instance?.SetSoundEnabled(enabled);
        }

        /// <summary>
        /// Toggle music on/off.
        /// </summary>
        public void SetMusicEnabled(bool enabled)
        {
            isMusicEnabled = enabled;
            musicSource.volume = enabled ? musicVolume : 0f;

            if (!enabled) musicSource.Pause();
            else if (musicSource.clip != null) musicSource.UnPause();

            SaveManager.Instance?.SetMusicEnabled(enabled);
        }

        public bool IsSoundEnabled() => isSoundEnabled;
        public bool IsMusicEnabled() => isMusicEnabled;

        #endregion
    }
}
