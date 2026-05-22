using UnityEngine;

namespace RushIndia.Data
{
    /// <summary>
    /// ScriptableObject defining all properties for a city environment.
    /// Create one asset per city: Right-click > Create > RushIndia > City Data.
    /// Each city has unique visuals, obstacles, music, and atmosphere.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCity", menuName = "RushIndia/City Data")]
    public class CityData : ScriptableObject
    {
        [Header("Identity")]
        public string cityId;          // Unique ID: "jaipur", "mumbai", etc.
        public string cityName;        // Display name: "Jaipur"
        public string stateName;       // State: "Rajasthan"
        [TextArea(2, 4)]
        public string description;     // Short flavor text

        [Header("Visuals")]
        public Sprite cityThumbnail;   // Selection screen thumbnail
        public Sprite cityBanner;      // Loading screen banner
        public Color primaryColor = Color.white;     // UI accent color
        public Color secondaryColor = Color.gray;

        [Header("Environment")]
        public Material roadMaterial;         // Road surface material
        public Color roadTintColor = Color.gray;
        public GameObject[] sideDecorations;  // Buildings, trees, props
        public GameObject[] backgroundProps;  // Distant landmarks
        public GameObject roadSegmentOverride; // Custom road segment prefab

        [Header("Obstacles (City-Specific)")]
        public GameObject[] cityObstacles;    // Unique obstacles for this city
        public string[] obstacleNames;        // For documentation: "Auto-rickshaw", "Camel", etc.

        [Header("Traffic Types")]
        public string[] trafficTypes;  // e.g., "auto_rickshaw", "bus", "cycle"

        [Header("Lighting & Weather")]
        public Color sunColor = Color.white;
        public float sunIntensity = 1f;
        public Color ambientColor = new Color(0.5f, 0.5f, 0.5f);
        public bool hasFog;
        public Color fogColor = Color.gray;
        public float fogDensity = 0.01f;

        [Header("Skybox")]
        public Material skyboxMaterial;
        public Color skyTintColor = Color.cyan;

        [Header("Audio")]
        public AudioClip backgroundMusic;
        public AudioClip ambientSFX;   // City ambient sounds
        public float musicTempo = 1f;  // For matching runner speed feel

        [Header("Difficulty Modifiers")]
        [Range(0.8f, 1.5f)]
        public float speedMultiplier = 1f;      // City-specific speed modifier
        [Range(0.5f, 2f)]
        public float obstacleFrequency = 1f;    // How often obstacles spawn
        [Range(0f, 1f)]
        public float narrowRoadChance = 0f;     // Chance of narrow sections

        [Header("Special Features")]
        public bool hasRainEffect;
        public bool hasNightMode;
        public bool hasDustEffect;
        public bool hasCrowdSounds;
        public string landmarkName;    // Featured landmark name
    }
}
