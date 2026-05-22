using UnityEngine;

namespace RushIndia.Data
{
    /// <summary>
    /// ScriptableObject defining a playable character.
    /// Create one asset per character: Right-click > Create > RushIndia > Character Data.
    /// Characters have unique models, animations, and unlock requirements.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "RushIndia/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [Header("Identity")]
        public string characterId;       // Unique ID: "chaiwala", "businessman"
        public string characterName;     // Display name: "Chaiwala"
        [TextArea(2, 3)]
        public string description;       // Flavor text

        [Header("Visuals")]
        public Sprite characterIcon;     // Shop/selection icon
        public Sprite characterFullArt;  // Full character artwork
        public GameObject characterPrefab; // 3D model prefab
        public RuntimeAnimatorController animatorController;

        [Header("Pricing")]
        public int coinPrice;            // Cost in coins (0 = free/default)
        public int gemPrice;             // Alternative gem price
        public bool isPremium;           // Only available via IAP
        public bool isFestivalSkin;      // Festival-limited skin

        [Header("Unlock Conditions")]
        public UnlockType unlockType;
        public int unlockRequirement;    // Games played, score needed, etc.

        [Header("Character Category")]
        public CharacterCategory category;

        [Header("Special Properties")]
        public float bonusScoreMultiplier = 1f;  // Some characters give bonus
        public string specialAbility;            // e.g., "Extra jump height"
        [Range(0f, 0.2f)]
        public float bonusAttribute = 0f;        // Percentage bonus

        [Header("Availability")]
        public bool isAvailableByDefault;  // Unlocked from start
        public string requiredCity;        // Only available in specific city (empty = all)
    }

    public enum UnlockType
    {
        Free,           // Available from start
        CoinPurchase,   // Buy with coins
        GemPurchase,    // Buy with gems
        IAP,            // Real money only
        Achievement,    // Unlock via gameplay milestone
        DailyReward,    // Unlock from daily rewards
        Festival        // Limited-time festival event
    }

    public enum CharacterCategory
    {
        Default,
        Street,        // Chaiwala, Delivery boy
        Professional,  // Businessman
        Sports,        // Cricket fan
        Festival,      // Holi, Diwali skins
        Premium        // IAP exclusive
    }
}
