using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Manages AdMob integration: Banner, Interstitial, and Rewarded ads.
    /// Uses stub/placeholder IDs - replace with real AdMob IDs before release.
    /// 
    /// TODO: Import Google Mobile Ads Unity Plugin:
    /// https://developers.google.com/admob/unity/start
    /// </summary>
    public class AdManager : MonoBehaviour
    {
        public static AdManager Instance { get; private set; }

        [Header("Ad Unit IDs (Replace with real IDs)")]
        // TODO: Replace these with your actual AdMob ad unit IDs
        [SerializeField] private string bannerAdId = "ca-app-pub-3940256099942544/6300978111";       // Test ID
        [SerializeField] private string interstitialAdId = "ca-app-pub-3940256099942544/1033173712"; // Test ID
        [SerializeField] private string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";     // Test ID

        [Header("Settings")]
        [SerializeField] private bool adsRemoved = false; // Set true if user purchased "Remove Ads"

        // Events
        public System.Action OnRewardedAdCompleted;
        public System.Action OnRewardedAdFailed;
        public System.Action OnInterstitialClosed;

        private bool isRewardedAdReady;
        private bool isInterstitialReady;

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
            InitializeAds();
        }

        /// <summary>
        /// Initialize the AdMob SDK. Call once at app start.
        /// TODO: Uncomment when Google Mobile Ads SDK is imported.
        /// </summary>
        private void InitializeAds()
        {
            Debug.Log("[AdManager] Initializing ads...");

            // TODO: Uncomment when SDK is imported:
            // MobileAds.Initialize(initStatus => {
            //     Debug.Log("[AdManager] AdMob initialized");
            //     LoadInterstitial();
            //     LoadRewarded();
            // });

            // Stub: pretend ads are loaded
            isInterstitialReady = true;
            isRewardedAdReady = true;

            Debug.Log("[AdManager] Ads initialized (stub mode)");
        }

        #region Banner Ads

        /// <summary>
        /// Show banner ad at bottom of screen (menus only).
        /// </summary>
        public void ShowBanner()
        {
            if (adsRemoved) return;

            Debug.Log($"[AdManager] Showing banner ad: {bannerAdId}");

            // TODO: Uncomment when SDK is imported:
            // BannerView bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Bottom);
            // AdRequest request = new AdRequest.Builder().Build();
            // bannerView.LoadAd(request);
        }

        /// <summary>
        /// Hide banner ad (during gameplay).
        /// </summary>
        public void HideBanner()
        {
            Debug.Log("[AdManager] Hiding banner ad");
            // TODO: bannerView.Hide();
        }

        #endregion

        #region Interstitial Ads

        /// <summary>
        /// Load interstitial ad for later showing.
        /// </summary>
        private void LoadInterstitial()
        {
            Debug.Log("[AdManager] Loading interstitial...");

            // TODO: Uncomment when SDK is imported:
            // AdRequest request = new AdRequest.Builder().Build();
            // InterstitialAd.Load(interstitialAdId, request, (ad, error) => {
            //     if (error != null) { Debug.LogError($"Interstitial load failed: {error}"); return; }
            //     isInterstitialReady = true;
            // });

            isInterstitialReady = true;
        }

        /// <summary>
        /// Show interstitial ad (between game rounds).
        /// </summary>
        public void ShowInterstitial()
        {
            if (adsRemoved) return;

            if (isInterstitialReady)
            {
                Debug.Log("[AdManager] Showing interstitial ad");
                isInterstitialReady = false;

                // TODO: Uncomment when SDK is imported:
                // interstitialAd.Show();

                // Reload for next time
                LoadInterstitial();
                OnInterstitialClosed?.Invoke();
            }
            else
            {
                Debug.Log("[AdManager] Interstitial not ready");
            }
        }

        #endregion

        #region Rewarded Ads

        /// <summary>
        /// Load rewarded ad.
        /// </summary>
        private void LoadRewarded()
        {
            Debug.Log("[AdManager] Loading rewarded ad...");

            // TODO: Uncomment when SDK is imported:
            // AdRequest request = new AdRequest.Builder().Build();
            // RewardedAd.Load(rewardedAdId, request, (ad, error) => {
            //     if (error != null) { Debug.LogError($"Rewarded load failed: {error}"); return; }
            //     isRewardedAdReady = true;
            //     ad.OnAdFullScreenContentClosed += () => { LoadRewarded(); };
            // });

            isRewardedAdReady = true;
        }

        /// <summary>
        /// Check if rewarded ad is available.
        /// </summary>
        public bool IsRewardedAdReady()
        {
            return isRewardedAdReady && !adsRemoved;
        }

        /// <summary>
        /// Show rewarded ad (e.g., continue after death, earn coins).
        /// </summary>
        public void ShowRewardedAd()
        {
            if (isRewardedAdReady)
            {
                Debug.Log("[AdManager] Showing rewarded ad");
                isRewardedAdReady = false;

                // TODO: Uncomment when SDK is imported:
                // rewardedAd.Show((reward) => {
                //     Debug.Log($"User earned reward: {reward.Amount} {reward.Type}");
                //     OnRewardedAdCompleted?.Invoke();
                // });

                // Stub: simulate reward
                OnRewardedAdCompleted?.Invoke();
                LoadRewarded();
            }
            else
            {
                Debug.Log("[AdManager] Rewarded ad not ready");
                OnRewardedAdFailed?.Invoke();
            }
        }

        #endregion

        /// <summary>
        /// Call when user purchases "Remove Ads" IAP.
        /// </summary>
        public void RemoveAds()
        {
            adsRemoved = true;
            HideBanner();
            SaveManager.Instance?.SetAdsRemoved(true);
            Debug.Log("[AdManager] Ads removed by user purchase");
        }
    }
}
