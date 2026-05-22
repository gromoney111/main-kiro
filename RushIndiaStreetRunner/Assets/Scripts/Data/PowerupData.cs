using UnityEngine;

namespace RushIndia.Data
{
    /// <summary>
    /// ScriptableObject defining a powerup type.
    /// Create one asset per powerup: Right-click > Create > RushIndia > Powerup Data.
    /// </summary>
    [CreateAssetMenu(fileName = "NewPowerup", menuName = "RushIndia/Powerup Data")]
    public class PowerupData : ScriptableObject
    {
        [Header("Identity")]
        public string powerupId;        // "magnet", "shield", "jetpack"
        public string powerupName;      // "Coin Magnet"
        [TextArea(1, 2)]
        public string description;      // "Attracts nearby coins"

        [Header("Visuals")]
        public Sprite icon;             // HUD indicator icon
        public Color glowColor = Color.yellow;
        public GameObject pickupPrefab; // 3D collectible model
        public GameObject activeFXPrefab; // VFX while active

        [Header("Gameplay")]
        public float duration = 8f;           // How long it lasts
        public float spawnWeight = 1f;        // Relative spawn chance
        public bool isStackable;              // Can extend duration if collected again
        public PowerupType type;

        [Header("Audio")]
        public AudioClip collectSFX;
        public AudioClip activeSFX;
        public AudioClip expireSFX;

        [Header("Upgrades")]
        public int maxLevel = 3;
        public float durationPerLevel = 2f;   // Extra seconds per upgrade level
        public int upgradeCostBase = 100;     // Coin cost for first upgrade
    }

    public enum PowerupType
    {
        CoinMagnet,
        Shield,
        Jetpack,
        DoubleCoins,
        SpeedBoost
    }
}
