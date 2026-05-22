using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Gameplay
{
    /// <summary>
    /// Character shop - allows players to browse, buy, and equip characters.
    /// Characters can be unlocked with coins, gems, or IAP.
    /// Indian street-style characters with festival skins.
    /// </summary>
    public class CharacterShop : MonoBehaviour
    {
        public static CharacterShop Instance { get; private set; }

        [Header("Character Catalog")]
        [SerializeField] private RushIndia.Data.CharacterData[] allCharacters;

        [Header("UI References")]
        [SerializeField] private Transform characterListParent;
        [SerializeField] private GameObject characterCardPrefab;

        // Currently equipped character
        private string equippedCharacterId;

        // Events
        public System.Action<string> OnCharacterEquipped;
        public System.Action<string> OnCharacterUnlocked;

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
            equippedCharacterId = Core.SaveManager.Instance?.GetSelectedCharacter() ?? "chaiwala";
            PopulateShop();
        }

        /// <summary>
        /// Populate the shop UI with all available characters.
        /// </summary>
        private void PopulateShop()
        {
            if (allCharacters == null || characterCardPrefab == null) return;

            foreach (var character in allCharacters)
            {
                // TODO: Instantiate card UI and set data
                // This would be done in a real implementation with a CharacterCardUI component
                Debug.Log($"[Shop] Character: {character.characterName} - {character.coinPrice} coins");
            }
        }

        /// <summary>
        /// Attempt to purchase a character with coins.
        /// </summary>
        public bool PurchaseWithCoins(string characterId)
        {
            var character = GetCharacterData(characterId);
            if (character == null) return false;

            if (IsUnlocked(characterId))
            {
                Debug.Log($"[Shop] Character already unlocked: {characterId}");
                return false;
            }

            if (Core.CoinManager.Instance != null && Core.CoinManager.Instance.SpendCoins(character.coinPrice))
            {
                UnlockCharacter(characterId);
                return true;
            }

            Debug.Log($"[Shop] Not enough coins for: {characterId}");
            return false;
        }

        /// <summary>
        /// Attempt to purchase a character with gems.
        /// </summary>
        public bool PurchaseWithGems(string characterId)
        {
            var character = GetCharacterData(characterId);
            if (character == null) return false;

            if (IsUnlocked(characterId)) return false;

            if (Core.CoinManager.Instance != null && Core.CoinManager.Instance.SpendGems(character.gemPrice))
            {
                UnlockCharacter(characterId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Unlock a character (from purchase or reward).
        /// </summary>
        public void UnlockCharacter(string characterId)
        {
            Core.SaveManager.Instance?.UnlockCharacter(characterId);
            OnCharacterUnlocked?.Invoke(characterId);
            Debug.Log($"[Shop] Unlocked: {characterId}");
        }

        /// <summary>
        /// Equip a character (must be unlocked first).
        /// </summary>
        public bool EquipCharacter(string characterId)
        {
            if (!IsUnlocked(characterId))
            {
                Debug.Log($"[Shop] Cannot equip locked character: {characterId}");
                return false;
            }

            equippedCharacterId = characterId;
            Core.SaveManager.Instance?.SetSelectedCharacter(characterId);
            OnCharacterEquipped?.Invoke(characterId);
            Debug.Log($"[Shop] Equipped: {characterId}");
            return true;
        }

        /// <summary>
        /// Check if a character is unlocked.
        /// </summary>
        public bool IsUnlocked(string characterId)
        {
            return Core.SaveManager.Instance?.IsCharacterUnlocked(characterId) ?? false;
        }

        /// <summary>
        /// Get character data by ID.
        /// </summary>
        public RushIndia.Data.CharacterData GetCharacterData(string characterId)
        {
            if (allCharacters == null) return null;
            foreach (var c in allCharacters)
            {
                if (c.characterId == characterId) return c;
            }
            return null;
        }

        /// <summary>
        /// Get currently equipped character ID.
        /// </summary>
        public string GetEquippedCharacterId() => equippedCharacterId;

        /// <summary>
        /// Get all character data for UI display.
        /// </summary>
        public RushIndia.Data.CharacterData[] GetAllCharacters() => allCharacters;
    }
}
