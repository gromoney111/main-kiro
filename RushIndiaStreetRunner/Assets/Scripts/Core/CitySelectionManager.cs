using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RushIndia.Core
{
    /// <summary>
    /// Manages the "Choose Your City" screen.
    /// Displays all 15 cities as selectable cards.
    /// Loads CityData ScriptableObjects and passes selection to GameManager.
    /// </summary>
    public class CitySelectionManager : MonoBehaviour
    {
        [Header("City Data")]
        [SerializeField] private RushIndia.Data.CityData[] allCities;

        [Header("UI References")]
        [SerializeField] private Transform cityGridParent;  // ScrollView content
        [SerializeField] private GameObject cityCardPrefab;  // Card template
        [SerializeField] private TextMeshProUGUI selectedCityName;
        [SerializeField] private TextMeshProUGUI selectedCityDescription;
        [SerializeField] private Image selectedCityPreview;
        [SerializeField] private Button playButton;
        [SerializeField] private Button backButton;

        private RushIndia.Data.CityData selectedCity;

        private void Start()
        {
            PopulateCityGrid();
            SetupButtons();

            // Default select first city
            if (allCities != null && allCities.Length > 0)
            {
                SelectCity(allCities[0]);
            }
        }

        /// <summary>
        /// Create city selection cards for all 15 cities.
        /// </summary>
        private void PopulateCityGrid()
        {
            if (cityCardPrefab == null || cityGridParent == null) return;
            if (allCities == null || allCities.Length == 0)
            {
                Debug.LogWarning("[CitySelection] No city data assigned!");
                return;
            }

            foreach (var city in allCities)
            {
                GameObject card = Instantiate(cityCardPrefab, cityGridParent);
                SetupCityCard(card, city);
            }
        }

        /// <summary>
        /// Configure a city card UI element.
        /// </summary>
        private void SetupCityCard(GameObject card, RushIndia.Data.CityData cityData)
        {
            // Set city name text
            var nameText = card.GetComponentInChildren<TextMeshProUGUI>();
            if (nameText != null)
                nameText.text = cityData.cityName;

            // Set city thumbnail
            var thumbnail = card.transform.Find("Thumbnail")?.GetComponent<Image>();
            if (thumbnail != null && cityData.cityThumbnail != null)
                thumbnail.sprite = cityData.cityThumbnail;

            // Add click listener
            var button = card.GetComponent<Button>();
            if (button != null)
            {
                // Capture cityData in closure
                var data = cityData;
                button.onClick.AddListener(() => SelectCity(data));
            }
        }

        /// <summary>
        /// Handle city selection - update preview and store choice.
        /// </summary>
        private void SelectCity(RushIndia.Data.CityData cityData)
        {
            selectedCity = cityData;

            AudioManager.Instance?.PlayButtonClick();

            // Update preview panel
            if (selectedCityName != null)
                selectedCityName.text = cityData.cityName;

            if (selectedCityDescription != null)
                selectedCityDescription.text = cityData.description;

            if (selectedCityPreview != null && cityData.cityThumbnail != null)
                selectedCityPreview.sprite = cityData.cityThumbnail;

            Debug.Log($"[CitySelection] Selected: {cityData.cityName}");
        }

        private void SetupButtons()
        {
            if (playButton != null)
                playButton.onClick.AddListener(OnPlayClicked);

            if (backButton != null)
                backButton.onClick.AddListener(OnBackClicked);
        }

        /// <summary>
        /// Start game with selected city.
        /// </summary>
        private void OnPlayClicked()
        {
            if (selectedCity == null)
            {
                Debug.LogWarning("[CitySelection] No city selected!");
                return;
            }

            AudioManager.Instance?.PlayButtonClick();
            GameManager.Instance?.SetSelectedCity(selectedCity.cityId);
            GameManager.Instance?.LoadScene("Gameplay");
        }

        private void OnBackClicked()
        {
            AudioManager.Instance?.PlayButtonClick();
            GameManager.Instance?.LoadScene("MainMenu");
        }
    }
}
