using UnityEngine;
using System.Collections.Generic;

namespace RushIndia.Data
{
    /// <summary>
    /// Utility to load city configurations from JSON at runtime.
    /// Alternative to using ScriptableObject assets for faster iteration.
    /// Can be used alongside SO-based CityData for hybrid approach.
    /// </summary>
    public static class CityConfigLoader
    {
        private const string CITY_CONFIG_PATH = "CityConfigs/AllCities";

        /// <summary>
        /// Load all city configurations from Resources JSON.
        /// </summary>
        public static List<CityConfigJSON> LoadAllCities()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(CITY_CONFIG_PATH);
            if (jsonFile == null)
            {
                Debug.LogError("[CityConfigLoader] Could not load AllCities.json from Resources!");
                return new List<CityConfigJSON>();
            }

            CityConfigWrapper wrapper = JsonUtility.FromJson<CityConfigWrapper>(jsonFile.text);
            return wrapper != null ? wrapper.cities : new List<CityConfigJSON>();
        }

        /// <summary>
        /// Get a specific city config by ID.
        /// </summary>
        public static CityConfigJSON GetCity(string cityId)
        {
            var cities = LoadAllCities();
            foreach (var city in cities)
            {
                if (city.cityId == cityId)
                    return city;
            }
            Debug.LogWarning($"[CityConfigLoader] City not found: {cityId}");
            return null;
        }
    }

    /// <summary>
    /// JSON-serializable city configuration.
    /// Mirrors CityData ScriptableObject fields for JSON loading.
    /// </summary>
    [System.Serializable]
    public class CityConfigJSON
    {
        public string cityId;
        public string cityName;
        public string stateName;
        public string description;
        public string primaryColor;
        public string secondaryColor;
        public string roadTintColor;
        public string[] obstacleNames;
        public string[] trafficTypes;
        public string sunColor;
        public float sunIntensity;
        public bool hasFog;
        public string fogColor;
        public float fogDensity;
        public bool hasRainEffect;
        public bool hasNightMode;
        public bool hasDustEffect;
        public bool hasCrowdSounds;
        public string landmarkName;
        public float speedMultiplier;
        public float obstacleFrequency;
        public float musicTempo;
        public string skyTintColor;
        public string ambientDescription;

        /// <summary>
        /// Parse hex color string to Unity Color.
        /// </summary>
        public Color GetPrimaryColor()
        {
            ColorUtility.TryParseHtmlString(primaryColor, out Color color);
            return color;
        }

        public Color GetSecondaryColor()
        {
            ColorUtility.TryParseHtmlString(secondaryColor, out Color color);
            return color;
        }

        public Color GetSunColor()
        {
            ColorUtility.TryParseHtmlString(sunColor, out Color color);
            return color;
        }
    }

    [System.Serializable]
    public class CityConfigWrapper
    {
        public List<CityConfigJSON> cities;
    }
}
