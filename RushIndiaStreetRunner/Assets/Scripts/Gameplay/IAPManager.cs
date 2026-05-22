using UnityEngine;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// In-App Purchase manager stub.
    /// Handles coin packs, gem packs, remove ads, premium characters.
    /// 
    /// TODO: Import Unity IAP package and implement IStoreListener.
    /// https://docs.unity3d.com/Manual/UnityIAP.html
    /// </summary>
    public class IAPManager : MonoBehaviour
    {
        public static IAPManager Instance { get; private set; }

        // TODO: Replace with your actual product IDs from Google Play Console
        public const string PRODUCT_REMOVE_ADS = "com.rushindiastreetrunner.removeads";
        public const string PRODUCT_COIN_PACK_SMALL = "com.rushindiastreetrunner.coins_500";
        public const string PRODUCT_COIN_PACK_MEDIUM = "com.rushindiastreetrunner.coins_2000";
        public const string PRODUCT_COIN_PACK_LARGE = "com.rushindiastreetrunner.coins_5000";
        public const string PRODUCT_GEM_PACK = "com.rushindiastreetrunner.gems_50";
        public const string PRODUCT_PREMIUM_BUNDLE = "com.rushindiastreetrunner.premium_bundle";
        public const string PRODUCT_FESTIVAL_PACK = "com.rushindiastreetrunner.festival_pack";

        // Events
        public System.Action<string> OnPurchaseCompleted;
        public System.Action<string> OnPurchaseFailed;

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
            InitializeIAP();
        }

        /// <summary>
        /// Initialize Unity IAP. Call once at app start.
        /// TODO: Uncomment when Unity IAP package is imported.
        /// </summary>
        private void InitializeIAP()
        {
            Debug.Log("[IAPManager] Initializing IAP (stub)...");

            // TODO: Uncomment when Unity IAP is set up:
            // var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            // builder.AddProduct(PRODUCT_REMOVE_ADS, ProductType.NonConsumable);
            // builder.AddProduct(PRODUCT_COIN_PACK_SMALL, ProductType.Consumable);
            // builder.AddProduct(PRODUCT_COIN_PACK_MEDIUM, ProductType.Consumable);
            // builder.AddProduct(PRODUCT_COIN_PACK_LARGE, ProductType.Consumable);
            // builder.AddProduct(PRODUCT_GEM_PACK, ProductType.Consumable);
            // builder.AddProduct(PRODUCT_PREMIUM_BUNDLE, ProductType.NonConsumable);
            // builder.AddProduct(PRODUCT_FESTIVAL_PACK, ProductType.NonConsumable);
            // UnityPurchasing.Initialize(this, builder);
        }

        /// <summary>
        /// Initiate a purchase by product ID.
        /// </summary>
        public void PurchaseProduct(string productId)
        {
            Debug.Log($"[IAPManager] Purchase requested: {productId}");

            // TODO: Uncomment when Unity IAP is set up:
            // storeController.InitiatePurchase(productId);

            // Stub: Simulate successful purchase for testing
            ProcessPurchase(productId);
        }

        /// <summary>
        /// Process a successful purchase and grant items.
        /// </summary>
        private void ProcessPurchase(string productId)
        {
            switch (productId)
            {
                case PRODUCT_REMOVE_ADS:
                    Core.AdManager.Instance?.RemoveAds();
                    break;

                case PRODUCT_COIN_PACK_SMALL:
                    Core.CoinManager.Instance?.AddCoins(500);
                    break;

                case PRODUCT_COIN_PACK_MEDIUM:
                    Core.CoinManager.Instance?.AddCoins(2000);
                    break;

                case PRODUCT_COIN_PACK_LARGE:
                    Core.CoinManager.Instance?.AddCoins(5000);
                    break;

                case PRODUCT_GEM_PACK:
                    Core.CoinManager.Instance?.AddGems(50);
                    break;

                case PRODUCT_PREMIUM_BUNDLE:
                    Core.CoinManager.Instance?.AddCoins(3000);
                    Core.CoinManager.Instance?.AddGems(30);
                    Core.SaveManager.Instance?.UnlockCharacter("businessman");
                    Core.SaveManager.Instance?.UnlockCharacter("cricket_fan");
                    break;

                case PRODUCT_FESTIVAL_PACK:
                    Core.SaveManager.Instance?.UnlockCharacter("holi_special");
                    Core.SaveManager.Instance?.UnlockCharacter("diwali_special");
                    Core.CoinManager.Instance?.AddGems(20);
                    break;

                default:
                    Debug.LogWarning($"[IAPManager] Unknown product: {productId}");
                    return;
            }

            OnPurchaseCompleted?.Invoke(productId);
            Debug.Log($"[IAPManager] Purchase completed: {productId}");
        }

        /// <summary>
        /// Restore previously purchased non-consumable items.
        /// Required for iOS, good practice for Android too.
        /// </summary>
        public void RestorePurchases()
        {
            Debug.Log("[IAPManager] Restoring purchases (stub)...");

            // TODO: Uncomment when Unity IAP is set up:
            // if (Application.platform == RuntimePlatform.Android)
            //     extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnRestoreComplete);

            // Check if ads were previously removed
            if (Core.SaveManager.Instance != null && Core.SaveManager.Instance.AreAdsRemoved())
            {
                Core.AdManager.Instance?.RemoveAds();
            }
        }
    }
}
