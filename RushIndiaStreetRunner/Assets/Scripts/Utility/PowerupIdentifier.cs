using UnityEngine;

namespace RushIndia.Utility
{
    /// <summary>
    /// Attach this to each powerup prefab to identify its type.
    /// When the player collects it, PowerupManager reads this to know
    /// which powerup to activate.
    /// 
    /// HOW TO USE:
    /// 1. Create a 3D object for the powerup (e.g., cube with magnet icon)
    /// 2. Add this script
    /// 3. Set the "Powerup Type" dropdown in Inspector
    /// 4. Add a SphereCollider with "Is Trigger" checked
    /// 5. Set Tag to "Powerup"
    /// </summary>
    public class PowerupIdentifier : MonoBehaviour
    {
        [Header("Set which powerup this object gives")]
        public PowerupPickupType powerupType = PowerupPickupType.CoinMagnet;

        /// <summary>
        /// Returns the string ID used by PowerupManager.ActivatePowerup()
        /// </summary>
        public string GetPowerupTypeString()
        {
            switch (powerupType)
            {
                case PowerupPickupType.CoinMagnet: return "Magnet";
                case PowerupPickupType.Shield: return "Shield";
                case PowerupPickupType.Jetpack: return "Jetpack";
                case PowerupPickupType.DoubleCoins: return "DoubleCoins";
                case PowerupPickupType.SpeedBoost: return "SpeedBoost";
                default: return "Magnet";
            }
        }
    }

    /// <summary>
    /// Dropdown-friendly enum for Inspector.
    /// </summary>
    public enum PowerupPickupType
    {
        CoinMagnet,
        Shield,
        Jetpack,
        DoubleCoins,
        SpeedBoost
    }
}
